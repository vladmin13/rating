using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Рейтинг
{
    [DataContract]
    public class Group:ServerObj
    { 
        [DataMember]
        string name;
        [DataMember]
        string spec;
        [DataMember]
        int curs;
        [DataMember]
        string fac;
        [DataMember]
        int starosta_id;

        public string Fac { get { return fac; } }

        public string Spec { get { return spec; } }
        public int Curs { get { return curs; } }
        public override string ToString()
        {
            return name;
        }
    }
}
