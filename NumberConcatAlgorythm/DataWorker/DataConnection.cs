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
        public string getWordByNumber(ulong number)
        {
            DictionaryDataContext data = new DictionaryDataContext();
            string word = (
                              from w in data.Words
                              where Equals(w.ID, number)
                              select w.word1
                           ).ToArray<string>()[0];
            return word;
        }

        //поиск порядкового номера слова в словаре
        public ulong getWordId(string word)
        {
            DictionaryDataContext data = new DictionaryDataContext();
            int idWord = (
                              from w in data.Words
                              where Equals(w.word1, word)
                              select w.ID
                           ).ToArray<int>()[0];
            return (ulong)idWord;
        }

        //подсчет количества слов в словаре
        public ulong getCountOfRows()
        {
            DictionaryDataContext data = new DictionaryDataContext();
            int idWord = (
                              from w in data.Words
                              select w.ID
                           ).Count();
            return (ulong)idWord;
        }

        public Array getAllWords()
        {
            DictionaryDataContext data = new DictionaryDataContext();
            Array Words = (
                              from w in data.Words
                              select w.word1
                           ).ToArray<string>();
            return Words;
        }
    }
}
