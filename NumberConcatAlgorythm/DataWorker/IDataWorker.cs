using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataWorker
{
    public interface IDataWorker
    {
        string GetWordById(int id);
        int GetWordsCount();
        int GetIdForWord(string word);
    }
}
