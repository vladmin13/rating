using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Рейтинг
{
  
        [DataContract]
        public class Person:ServerObj
        {
       
            [DataMember]
            string name;
            [DataMember]
            string fullname;
            [DataMember]
            string tel;
            [DataMember]
            string status;
            [DataMember]
            string fathername;



            public string Name { get { return name; } }
            public string Fullname { get { return fullname; } }
            public string FIO { get { return fullname + " " + name + " " + fathername; } }

            public virtual string getPersonString() {

                return fullname +" "+ name;
            }
           }
}
