using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#if __MOBILE__ 
using RetingPRO;
#endif
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
#if __MOBILE__ 
#else
using System.Windows.Forms;
#endif
using Рейтинг.ProgClass;
using static Рейтинг.Server;

namespace Рейтинг
{

    static class Server
    {

        public static MyInfo myInfo = new MyInfo();
        public static BindingList<Predmet> mylistPredmet;
        public static BindingList<Group> mylistGroup;
        public static BindingList<Lesson> mylistLesson;

        public static ListSendToServer listISendToServer = new ListSendToServer();
        public static string servUrl= "http://rating.polessu.by/grandAPI/";

        public delegate void SendMessages(string messages);
        public delegate BindingList<Predmet> ItemPredmetSelect(BindingList<Predmet> s1, BindingList<Lesson> s2);
        public delegate BindingList<Group> ItemGroupSelect(BindingList<Group> s1, BindingList<Lesson> s2);



#if __MOBILE__

         public static async Task<bool> LoginM(string login, string pass)
        {
            Person p;
            JObject servObj = JObject.Parse(await GetUrlToString(Server.servUrl+"GET/login.php?login="+login+"&pass="+pass+"&mob=1"));
            switch ((int)servObj["status"])
            {
                case 1:
                    string otv = (string)servObj["info"];
                    MainActivity.myperson= (Person)JsonConvert.DeserializeObject<MyInfo>(otv);
                    return true;
                    break;
                case 2:
                     otv = (string)servObj["info"];
                    MainActivity.myperson = (Person)JsonConvert.DeserializeObject<Student>(otv);
                    return true;
                    //ученик
                    break;
                
                default: return false;
            }
           

        
        
        }


#else
        public static async Task<Person> Login(string login, string pass)
        {
            JObject servObj = JObject.Parse(await GetUrlToString(Server.servUrl+"GET/login.php?login=" + login + "&pass=" + pass));
            if ((bool)servObj["status"])
            {

                string otv = (string)servObj["prepod_info"];
                myInfo = JsonConvert.DeserializeObject<MyInfo>(otv);

                Properties.Settings.Default.loginOk = true;
                Properties.Settings.Default.Save();

                //загрузка параметров 
                await  GetInfo();

                return myInfo;

            }
            else
            {

                Properties.Settings.Default.loginSave = false;
                Properties.Settings.Default.login = "";
                Properties.Settings.Default.pass = "";
                Properties.Settings.Default.Save();
                MessageBox.Show("Неверный логин или пароль!");
                return null;
            };


        }
#endif



        public static async Task<string> GetUrlToString(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = await request.GetResponseAsync();
                return new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            }
            catch (System.Net.WebException)
            {

#if __MOBILE__
#else
                MessageBox.Show("Невозможно подключится к интернет ресурсам! Проверте подключение к интернету и перезапустите программу.", "Ошибка подключения к интернету.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
#endif
                return "";
            }

        }

        public static async Task GetInfo()
        {

            mylistPredmet = JsonConvert.DeserializeObject<BindingList<Predmet>>(await GetUrlToString(Server.servUrl+"GET/predmets.php?id=" + Server.myInfo.Id));
            mylistGroup = JsonConvert.DeserializeObject<BindingList<Group>>(await GetUrlToString(Server.servUrl+"GET/groups.php?id=" + Server.myInfo.Id));
            mylistLesson = JsonConvert.DeserializeObject<BindingList<Lesson>>(await GetUrlToString(Server.servUrl+"GET/lessons.php?id=" + Server.myInfo.Id));

        }
#if __MOBILE__

        public static async Task GetMobInfo(string ID) {

            MainActivity.mylesson = JsonConvert.DeserializeObject<BindingList<Lesson>>(await GetUrlToString(Server.servUrl+"GET/lessons.php?id=" + ID + "&mob=1"));
            
        }
#endif

        public static async Task<BindingList<Student>> getClass(int id_gr)
        {


            return JsonConvert.DeserializeObject<BindingList<Student>>(await GetUrlToString(Server.servUrl+"GET/students.php?id_gr=" + id_gr));


        }






        public static async Task sendToServer()
        {
            try
            {
                foreach (var item in listISendToServer)
            {
                    switch (item.goStatusNessage())
                    {

                        case ServerStatusEnum.Add:
                            var cl = new HttpClient();
                            var pairs = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("db",item.goToServInfo().DB),
                            new KeyValuePair<string, string>("value", item.goToServInfo().SQLData)
                             };
                            var content = new FormUrlEncodedContent(pairs);
                            var resp =await cl.PostAsync(Server.servUrl+"ADD/addobj.php", content);
                            string ids =await resp.Content.ReadAsStringAsync();
                            item.sendServID(ids);
                            /*
                            var wb = new WebClient();

                            var data = new NameValueCollection();
                            data["db"] = item.goToServInfo().DB;
                            data["value"] = item.goToServInfo().SQLData;
                            Uri u = new Uri(Server.servUrl+"ADD/addobj.php");
                            var response = await wb.UploadValuesTaskAsync(u, "POST", data);
                            string ids = Encoding.ASCII.GetString(response);
                            item.sendServID(ids);
                            */
                            break;

                        case ServerStatusEnum.Update:
                            var clU  = new HttpClient();
                            var   pairsU = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("db",item.goToServInfo().DB),
                                new KeyValuePair<string, string>("value", item.goToServInfo().SQLData),
                                new KeyValuePair<string, string>("id",item.goToServInfo().ID.ToString())

                             };
                           var  contentU = new FormUrlEncodedContent(pairsU);
                          var   respU = await clU.PostAsync(Server.servUrl+"update.php", contentU);
                          string   idsU = await respU.Content.ReadAsStringAsync();
                            item.sendServID(idsU);
                            /*
                            var wbU = new WebClient();

                            var dataU = new NameValueCollection();
                            dataU["db"] = item.goToServInfo().DB;
                            dataU["value"] = item.goToServInfo().SQLData;
                            dataU["id"] = item.goToServInfo().ID.ToString();
                            var responseU = await wbU.UploadValuesTaskAsync(Server.servUrl+"update.php", "POST", dataU);
                            string idsU = Encoding.ASCII.GetString(responseU);
                            item.sendServID(idsU);
                            */
                            break;
                        case ServerStatusEnum.Delete:
                            break;

                    }
                                  

                }
                listISendToServer.Clear();
            }
            catch (System.Net.WebException)
            {
#if __MOBILE__
#else
                MessageBox.Show("Невозможно подключится к интернет ресурсам! Данные или часть данных небыла передана на сервер, пожалуйста проверте данные которые вы вводили", "Ошибка подключения к интернету.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
#endif
            }
        }
    }
    class ListSendToServer : List<ISendToServer>
    {
        public event SendMessages UserEvent;
        public new void Clear()
        {

            base.Clear();
            UserEvent("Передача данных на сервер законченна!))");

        }


    }



    public struct BoolAll
    {
        bool Group;
        bool Predmet;
        public BoolAll(bool h)
        {
            Group = h;
            Predmet = h;
        }
        public bool gerStatusBool()
        {

            if (Group && Predmet)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void setGroup()
        {
            Group = true;
        }
        public void setPredmet()
        {
            Predmet = true;
        }

        public void clearAllBool()
        {
            Group = false;
            Predmet = false;
        }
    }

}
