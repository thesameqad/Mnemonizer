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
        [OperationContract]
        /*[WebGet( ResponseFormat = WebMessageFormat.Json)]*/
        [WebGet(UriTemplate = "?enterString={enterString}", ResponseFormat = WebMessageFormat.Json)]
        string GetMnemonicString(string enterString);
      [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        string GetOriginalString(string mnemonicString);
        
    }
}
