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
using System.ComponentModel;
using Рейтинг.ProgClass;
using static Android.Views.ViewGroup;

namespace RetingPRO
{
    [Activity(Label = "РейтингПРО")]
    public class ActivityDost : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            stopProcesB();
            int id = Intent.GetIntExtra("id", 0);
            ((TextView)FindViewById(Resource.Id.text)).Text = "Список оценок по дисцеплине \"" + MainActivity.mylesson[id].PredmetName+"\":";
            var list1 = new List<IDictionary<string, object>>();
            
            foreach (var itemz in MainActivity.mylesson[id].Zanatie)
            {
                foreach (var itemd in itemz.Dost)
                {
                    if(itemd.Student_id == MainActivity.myperson.Id){
                        var item1 = new JavaDictionary<string, object>();
                        item1.Add("namez",itemz.Name);
                        item1.Add("ocenka", itemd.Ocenka);
                        item1.Add("date", itemz.Data.ToLongDateString());
                        list1.Add(item1);
                    }
                }
            }
           
         
            string[] from = { "namez", "ocenka", "date" };
            int[] to = { Resource.Id.name, Resource.Id.ocenka, Resource.Id.date };
            SimpleAdapter newslistAdapter = new SimpleAdapter(this, list1,Resource.Layout.item, from,to);
            ListView newsList = (ListView)FindViewById(Resource.Id.listView1);
            LayoutParams lpView = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            TextView tv = new TextView(this);
            tv.Text ="Пусто";
            tv.LayoutParameters=lpView;

            newsList.EmptyView = tv;
            newsList.Adapter = newslistAdapter;
        }
        private void startProcesB()
        {
            ProgressBar progressBar = (ProgressBar)FindViewById(Resource.Id.progress_bar);
            progressBar.Visibility = Android.Views.ViewStates.Visible;
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
    }
}