using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel.Web;

namespace ServiceJson
{
    [DataContract]
    public class OperationService
    {
        [DataMember]
        public String MnemonicString { get; set; }
        [DataMember]
        public String resultString { get; set; }
    }
}