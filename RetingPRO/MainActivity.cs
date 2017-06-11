using Android.App;
using Android.Widget;
using Android.OS;
using Plugin.Settings;
using Android.Content;
using Рейтинг;
using Android.Runtime;
using System.ComponentModel;
using Рейтинг.ProgClass;
using System.Threading.Tasks;
using Android.Views;


namespace RetingPRO
{
    [Activity(Label = "РейтингПРО", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static Person myperson;
        protected Student stinfo;
        public static BindingList<Lesson> mylesson;
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //если запускается впервые программа

            SetContentView(Resource.Layout.Main);
            if (CrossSettings.Current.GetValueOrDefault<bool>("onVKL", false)) getOnStart();
            startProcesB();
            if (!CrossSettings.Current.GetValueOrDefault<bool>("saveLogin"))
            {
                stopProcesB();
                StartActivity(new Intent(this, typeof(ActivityLogin)));
            }
            else {
                if (!await Server.LoginM(CrossSettings.Current.GetValueOrDefault<string>("login"), CrossSettings.Current.GetValueOrDefault<string>("pass")))
                {
                    stopProcesB();
                    CrossSettings.Current.AddOrUpdateValue<bool>("saveLogin", false);
                    StartActivity(new Intent(this, typeof(ActivityLogin)));
                }
                else {

                   await start();

                }


            }

        }


        protected async Task start() {
            stinfo = (Student)myperson;
           await Server.GetMobInfo(stinfo.Id.ToString());
            string[] slist = new string[mylesson.Count];
            for (int i= 0; i<mylesson.Count; i++)
            {
                await mylesson[i].GetZanyatie();
                slist[i] = mylesson[i].PredmetName;
               
            }
            ListView list = (ListView)FindViewById(Resource.Id.listView1);
            ArrayAdapter<string> arAd = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,slist) ;
            list.SetAdapter(arAd);
            list.ItemClick += (sender, e) => {
            Intent intent = new Intent(this, typeof(ActivityDost));
            intent.PutExtra("id", e.Position);
                StartActivity(intent);
            };
            stopProcesB();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Выход");
        
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            CrossSettings.Current.AddOrUpdateValue<bool>("saveLogin", false);
            StartActivity(new Intent(this, typeof(ActivityLogin)));

            return base.OnOptionsItemSelected(item);
        }
        protected async override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                if (myperson.GetType() == typeof(Рейтинг.MyInfo))
                {
                    Toast toast = Toast.MakeText(this.ApplicationContext,
                                            "Версия для преподователей скоро будет)))))", ToastLength.Long);
                    toast.Show();
                    CrossSettings.Current.AddOrUpdateValue<bool>("saveLogin", false);
                    StartActivityForResult(new Intent(this, typeof(ActivityLogin)), 0);
                }
                else
                {
                   await start();
                }
            }
        }

        private void startProcesB() {
            ProgressBar progressBar = (ProgressBar)FindViewById(Resource.Id.progress_bar);
            progressBar.Visibility =Android.Views.ViewStates.Visible;
            TextView text = (TextView)FindViewById(Resource.Id.text_progress_bar);
            text.Visibility = Android.Views.ViewStates.Visible;
        }
        private void stopProcesB()
        {
            ProgressBar progressBar = (ProgressBar)FindViewById(Resource.Id.progress_bar);
            progressBar.Visibility = Android.Views.ViewStates.Invisible;
            TextView text = (TextView)FindViewById(Resource.Id.text_progress_bar);
            text.Visibility = Android.Views.ViewStates.Invisible;
        }
        private void getOnStart() {
            
            CrossSettings.Current.AddOrUpdateValue<bool>("onVKL", true);
            CrossSettings.Current.AddOrUpdateValue<bool>("saveLogin", false);
        }
    }
}

