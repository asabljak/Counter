using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyCounter
{
    [DataContract]
    class MyItem
    {
        [DataMember]
        public string title { get; set; }

        [DataMember]
        public int value { get; set; }

    }
}
