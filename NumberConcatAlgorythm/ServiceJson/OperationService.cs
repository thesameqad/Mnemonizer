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
  
        public OperationService(string Str,string Word)
        {
            this.resultString = Str;
            this.MnemonicString = Word;
        }
        [DataMember]
        public string MnemonicString { get; set; }
        [DataMember]
        public string resultString { get; set; }

    }
}