using System;
using System.Runtime.Serialization;

namespace data.Models
{
    [DataContract]
    public class PutChange{      
         
        [DataMember]
        public  String date { get; set; }
        [DataMember]
        public  long value { get; set; }
        [DataMember]
        public  char op { get; set; }

    }
    
    }