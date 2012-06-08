using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataWorker
{
    public class DataConnection
    {
        //поиск слова по номеру в словаре
        public string getWordByNumber(int number)
        {
            DictionaryDataContext data = new DictionaryDataContext();
            string word = (
                              from w in data.Words
                              where Equals(w.Id, number)
                              select w.word
                           ).ToArray<string>()[0];
            return word;
        }

        //поиск порядкового номера слова в словаре
        public ulong getWordId(string word)
        {
            DictionaryDataContext data = new DictionaryDataContext();
            int idWord = (
                              from w in data.Words
                              where Equals(w.word, word)
                              select w.Id
                           ).ToArray<int>()[0];
            return (ulong)idWord;
        }

        //подсчет количества слов в словаре
        public int getCountOfRows()
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
