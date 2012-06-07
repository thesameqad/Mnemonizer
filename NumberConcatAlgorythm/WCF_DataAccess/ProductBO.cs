using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;
namespace WCF_DataAccess
{
    [DataContract]  
    public class ProductBO
    {
        [DataMember] 
        public int ID { get; set; }
        [DataMember]
        public string word { get; set; }
    }
}