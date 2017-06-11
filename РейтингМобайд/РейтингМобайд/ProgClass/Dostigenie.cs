using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Рейтинг.ProgClass
{
    [DataContract]
    public class Dostigenie:ServerObj,ISendToServer
    {

    
        [DataMember]
        int student_id;
        [DataMember]
        int zanatie_id;
        [DataMember]
        short ocenka;

        static  string db = "Dostigenie";
        ServerStatusEnum sse;
        public Dostigenie()
        {
            sse = ServerStatusEnum.Get;
        }
        public Dostigenie(int stud_id,int zan_id,string oc)
        {
            student_id = stud_id;
            zanatie_id = zan_id;
            if (Int16.TryParse(oc, out ocenka))
                sse = ServerStatusEnum.Add;
            else sse = ServerStatusEnum.Get;
        }
        public int Student_id { get { return student_id; } }
        public int Ocenka { get { return ocenka; } }

        public ServerStatusEnum goStatusNessage()
        {
            return sse;
        }

        public ServerSendStruct goToServInfo()
        {
            ServerSendStruct st =new ServerSendStruct();
            st.set(db, @" (`id` ,`student_id` ,`zanatie_id` ,`ocenka`) VALUES(NULL, '"+ student_id+"', '"+zanatie_id+"', '"+ocenka+"');",Id);
            
            return st;
        }

        public void setNew(string val)
        {
            if (Int16.TryParse(val, out ocenka));
            if(sse==ServerStatusEnum.Get)
                sse = ServerStatusEnum.Update;
        }

        public void sendServID(string id)
        {
            setID(Int16.Parse(id));
        }
    }
}
