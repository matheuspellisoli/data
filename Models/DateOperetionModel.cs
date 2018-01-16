using System;
using System.Runtime.Serialization;

namespace data.Models
{
        public class DateOperetion{
        
      
        [DataMember]
        public String date { get; set; }
        
        [DataMember]
        public  long value  { get; set; }
        
        [DataMember]
         public  char op  { get; set; }


         
    
    }
}