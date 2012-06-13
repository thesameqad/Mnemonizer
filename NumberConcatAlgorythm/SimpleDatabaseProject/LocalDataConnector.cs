using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SimpleDatabaseProject
{
    public class LocalDataConnector
    {
        private SampleDatabaseEntities1 DatabaseContent = new SampleDatabaseEntities1();

        public string GetWordById(int id)
        {
            return DatabaseContent.Words.Where(w => w.ID == id).FirstOrDefault().Word;
        }

        public int GetIdForWord(string word)
        {
            return DatabaseContent.Words.Where(w => w.Word == word).FirstOrDefault().ID;
        }

        public int GetWordsCount()
        {
            return DatabaseContent.Words.ToList().Count;
        }
    }
}
