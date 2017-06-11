using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Рейтинг.ProgClass;

namespace Рейтинг
{
    [DataContract]
    public class Student:Person
    {
        [DataMember]
        int group_id;
       

        BindingList<Dostigenie> dost = new BindingList<Dostigenie>();
        public BindingList<Dostigenie> Dost { get { return dost; } }

        public override string ToString()
        {
            return Fullname+ Name;
        }
    }
}
