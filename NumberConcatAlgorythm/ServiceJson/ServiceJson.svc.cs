using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Coder;
using System.Numerics;
using DataWorker.XmlDataWorker;

namespace ServiceJson
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceJson" in code, svc and config file together.
    public class ServiceJson : IServiceJson
    {

      private MnemonicCoder coder;

      public ServiceJson()
      {
          coder = new MnemonicCoder();
          //coder.DataWorker = new XmlDataWorker();
      }

      public OperationService GetMnemonicString(string enterString)
      {
          return new OperationService { MnemonicString = coder.GetMnemonicString(enterString), resultString = enterString };
      }

      public OperationService GetOriginalString(string enterString)
      {
          return new OperationService { MnemonicString = enterString, resultString = coder.GetOriginalString(enterString) };
      }
    }
}
