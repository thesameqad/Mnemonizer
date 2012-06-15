using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service_Mnemonizer
{
    
    [ServiceContract]
    public interface IServiceMnemonizer
    {
       [OperationContract]
        String mnemoCode(String text);
       [OperationContract]
        String mnemogetdecode(String text);
    }

    
}
