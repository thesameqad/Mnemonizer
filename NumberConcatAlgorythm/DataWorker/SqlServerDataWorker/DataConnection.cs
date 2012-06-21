using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataWorker.SqlServerDataWorker
{
    public class DataConnection:IDataWorker
    {
        public string GetWordById(int id)
        {
            DictionaryDataContext data = new DictionaryDataContext();
            string word= (
                              from w in data.Words
                              where Equals(w.Id, id)
                              select w.word
                           ).FirstOrDefault();
            if (word == null)
                throw new ArgumentNullException("There were no word founded");

            return word;
        }

        public int GetIdForWord(string word)
        {
            DictionaryDataContext data = new DictionaryDataContext();
            int wordId = (
                              from w in data.Words
                              where Equals(w.word, word)
                              select w.Id
                           ).FirstOrDefault();
            if (wordId <= 0) 
                throw new ArgumentNullException("There were no word founded");
            return wordId;
        }

        public int GetWordsCount()
        {
            DictionaryDataContext data = new DictionaryDataContext();
            int idWord = (
                              from w in data.Words
                              select w.Id
                           ).Count();
            return idWord;
        }
    }
}
