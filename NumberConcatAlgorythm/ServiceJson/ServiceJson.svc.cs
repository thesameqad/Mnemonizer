using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Coder;
using System.Numerics;

namespace ServiceJson
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceJson" in code, svc and config file together.
    public class ServiceJson : IServiceJson
    {
      private MnemonicCoder coder = new MnemonicCoder();
      
        public string GetMnemonicString(string enterString)
        {

            return coder.GetMnemonicString(enterString);
            
         
        }

       public string GetOriginalString(string mnemonicString)
        {
            return coder.GetOriginalString(mnemonicString);
        }
    }
}
