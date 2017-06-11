using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Рейтинг;
using Plugin.Settings;

namespace RetingPRO
{
    [Activity(Label = "Авторизация")]
    public class ActivityLogin : Activity
    {
        protected  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutLogin);
            Button buttonLogin = (Button)FindViewById(Resource.Id.buttonLogin);
            buttonLogin.Click += async(sender, e) => {
                if(((EditText)FindViewById(Resource.Id.editTextLogin)).Text.Length!=0& ((EditText)FindViewById(Resource.Id.editTextPass)).Text.Length != 0)
                {
                    ((Button)sender).Enabled = false;
                    CrossSettings.Current.AddOrUpdateValue<string>("login", ((EditText)FindViewById(Resource.Id.editTextLogin)).Text);
                    CrossSettings.Current.AddOrUpdateValue<string>("pass", ((EditText)FindViewById(Resource.Id.editTextPass)).Text);
                    if (await Server.LoginM(((EditText)FindViewById(Resource.Id.editTextLogin)).Text, ((EditText)FindViewById(Resource.Id.editTextPass)).Text))
                    {
                        CrossSettings.Current.AddOrUpdateValue<bool>("saveLogin", true);
                        Intent intent = new Intent(this, typeof(MainActivity));
                        intent.PutExtra("ok", true);
                        SetResult(Result.Ok, intent);
                       
                        this.Finish();
                    }
                    ((Button)sender).Enabled = true;
                    
                }
            };
            // Create your application here
        }
        public override void OnBackPressed()
        {
            var transaction = FragmentManager.BeginTransaction();
            var dialogFragment = new AlertDialogFragment();
            dialogFragment.Show(transaction, "dialog_fragment");
        }
        
}
    public class AlertDialogFragment : DialogFragment
    {
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            EventHandler<DialogClickEventArgs> okhandler;
            var builder = new AlertDialog.Builder(Activity)
                .SetMessage("Выйти?")
                .SetNeutralButton("Да", (sender, args) =>
                {
                    Activity.FinishAffinity();
                })
                .SetPositiveButton("Нет", (sender, args) =>
                {
                    // Do something when this button is clicked.
                })
                .SetTitle("Выход:");
            return builder.Create();
        }
    }
}