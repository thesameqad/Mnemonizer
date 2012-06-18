using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SampleDatabaseProject
{
    public class LocalDataConnector
    {
        private SampleDatabaseEntities1 DatabaseContent = new SampleDatabaseEntities1("metadata=res://*/SampleDataModel.csdl|res://*/SampleDataModel.ssdl|res://*/SampleDataModel.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=\" Data Source=../../../SimpleDatabaseProject/SampleDatabase.sdf\"");
        //private SampleDatabaseEntities1 dm = new SampleDatabaseEntities1();

        public LocalDataConnector()
        {      

        }

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
