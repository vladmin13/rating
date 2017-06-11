using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Рейтинг.ProgClass
{
    [DataContract]
    public class Zanatie : ServerObj,ISendToServer
    {
        [DataMember]
        string name;
        [DataMember]
        DateTime data;
        [DataMember]
        int lesson_id;

        static string db = "Zanatie";
        BindingList< Dostigenie> dost = new BindingList<Dostigenie>();

        public DateTime Data { get { return data; } }
        public  BindingList<Dostigenie> Dost { get { if (dost.Count == 0) { return dost; } else return dost; } }

        public string Name { get { return name; } }
        ServerStatusEnum sse;
        public   Zanatie()
        {
            sse = ServerStatusEnum.Get;
            

        }
        public Zanatie(string name,DateTime date,int l_id)
        {
            this.name = name;
            this.data = date;
            this.lesson_id = l_id;
            sse = ServerStatusEnum.Add;
        }
        
        public async Task getDostA() {
            if (Id != 0)
            {
                dost = JsonConvert.DeserializeObject<BindingList<Dostigenie>>(await Server.GetUrlToString(Server.servUrl+"GET/dost.php?id=" + Id));
            }

        }
        public string ToCol()
        {
            return name+" ("+data.ToShortDateString()+")";
        }

        public ServerStatusEnum goStatusNessage()
        {
            return sse;
        }

        public ServerSendStruct goToServInfo()
        {

            ServerSendStruct st = new ServerSendStruct();
            st.set(db, @" (`id` ,`name` ,`lesson_id` ,`data`) VALUES(NULL, '" + name + "', '" + lesson_id + "', '" + data.ToString("yyyy-MM-dd") + "')",Id);

            return st;

        }
        public void sendServID(string id)
        {
            setID(Int16.Parse(id));
        }
    }
}
