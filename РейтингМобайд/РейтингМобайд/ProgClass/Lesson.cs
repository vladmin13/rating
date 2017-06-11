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
    public class Lesson:ServerObj
    {
        [DataMember]
        int predmet_id;
        [DataMember]
        int prepodovatel_id;
        [DataMember]
        int group_id;
        [DataMember]
        int allGroup;



        BindingList<Zanatie> zanatie;
        string predmetName;

        public int Predmet_id { get { return predmet_id; } }
        public string PredmetName { get { return predmetName; } }
        public int Prepodovatel_id { get { return prepodovatel_id; } }
        public int Group_id { get { return group_id; } }
        public bool AllGroup { get { if (allGroup == 0) return true; else return false; } }

        public BindingList<Zanatie> Zanatie { get { return zanatie; } }

        public async Task<BindingList<Zanatie>> GetZanyatie()
        {

            predmetName = await Server.GetUrlToString(Server.servUrl+"GET/predmets.php?id=" + Id+"&mob=1");
            zanatie = JsonConvert.DeserializeObject<BindingList<Zanatie>>(await Server.GetUrlToString(Server.servUrl+"GET/zanatie.php?id=" + Id));
            foreach (var item in zanatie)
            {
               await item.getDostA();
            }
                return zanatie;
           
        }
    }
}
