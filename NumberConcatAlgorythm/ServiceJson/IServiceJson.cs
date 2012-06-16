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
        [OperationContract]
        [WebGet(UriTemplate = "Original?enterString={enterString}", ResponseFormat = WebMessageFormat.Json)]
        string GetOriginalString(string enterString);
        [OperationContract]
        [WebGet(UriTemplate = "Mnemonic?enterString={enterString}", ResponseFormat = WebMessageFormat.Json)]
        string GetMnemonicString(string enterString);
    }
}
