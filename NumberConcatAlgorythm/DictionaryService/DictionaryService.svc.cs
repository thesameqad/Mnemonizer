using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DictionaryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class DictionaryService : IDictionaryService
    {
        private DictionaryEntities model = new DictionaryEntities();
        public string GetWordById(int id)
        {
            return model.Words.Where(w => w.ID == id).FirstOrDefault().Word;
        }

        public ulong GetIdForWord(string word)
        {
            return (ulong)model.Words.Where(w => w.Word == word).FirstOrDefault().ID;
        }

        public int GetWordsCount()
        {
            return model.Words.ToList().Count;
        }
    }
}
