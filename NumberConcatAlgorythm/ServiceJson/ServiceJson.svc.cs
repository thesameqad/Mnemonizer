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
      // private MnemonicCoder coder = new MnemonicCoder();
        //!!!Что бы проверить работу нужно в URL вписать:  http://localhost:2934/ServiceJson.svc/?enterString=asddaf
        //если не вызывать методы MnemonicCoder, то все работает и возвращает Json, если вызывать , то все валиться
        //валиться начинает с private MnemonicCoder coder = new MnemonicCoder();
        public OperationService GetMnemonicString(string enterString)
        {

            OperationService JsonStr = new OperationService(enterString, "jjj");//coder.GetMnemonicString(enterString));
                    
            return JsonStr;
         
        }


      /*  public string GetOriginalString(string mnemonicString)
        {
            return coder.GetOriginalString(mnemonicString);
        }*/
    }
}
