using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace ServiceJson
{
    [ServiceContract]
    public interface IServiceJson
    {

        [WebGet(UriTemplate = "Original?enterString={enterString}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]        
        OperationService GetOriginalString(string enterString);

        [WebGet(UriTemplate = "Mnemonic?enterString={enterString}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        OperationService GetMnemonicString(string enterString);
    }

}
