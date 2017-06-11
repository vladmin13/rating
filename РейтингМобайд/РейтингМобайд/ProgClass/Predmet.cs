using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Рейтинг.ProgClass
{
    [DataContract]
    public class Predmet:ServerObj
    {
        [DataMember]
        string name;
        [DataMember]
        string shortn;

        public string Name { get { return name; } }
        public override string ToString()
        {
            return shortn;
        }
    }
}
