using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace ServiceJson
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceJson" in both code and config file together.
    [ServiceContract]
    public interface IServiceJson
    {
        [WebGet(UriTemplate = "GetOriginal/{enterString}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        OperationService GetOriginalString(string enterString);

        [WebGet(UriTemplate = "GetMnemonic/{enterString}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        OperationService GetMnemonicString(string enterString);
        
    }
}
