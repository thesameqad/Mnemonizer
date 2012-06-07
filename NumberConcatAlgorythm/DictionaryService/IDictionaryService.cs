using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DictionaryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDictionaryService
    {

        [OperationContract]
        string GetWordById(int id);

        [OperationContract]
        ulong GetIdForWord(string word);

        [OperationContract]
        int GetWordsCount();

    }

}
