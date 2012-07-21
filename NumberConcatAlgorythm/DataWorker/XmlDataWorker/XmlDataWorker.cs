using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using System.Xml;
using DataWorker;

namespace DataWorker.XmlDataWorker
{
    public class XmlDataWorker:IDataWorker
    {
        private XDocument dictionary;

        public XmlDataWorker(string fileName)
        {
            Stream file = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);
            dictionary = XDocument.Load(file);
        }

        public string GetWordById(int id)
        {
            string word = (string)(from w in dictionary.Root.Elements("Words")
                                   where (int)w.Element("Id") == id
                                   select w.Element("Word")
                           ).FirstOrDefault();
            if (word == null)
            {
                throw new ArgumentNullException("There were no word founded");
            }
            return word;
        }

        public int GetWordsCount()
        {
            int count = (from w in dictionary.Root.Elements("Words")
                          select w.Element("Id")
                         ).Count();
            return count;
        }

        public int GetIdForWord(string word)
        {
            int idWord = (int)(from w in dictionary.Root.Elements("Words")
                               where Equals((string)w.Element("Word"), word)
                               select w.Element("Id")
                         ).FirstOrDefault();
            if (idWord <= 0)
            {
                throw new ArgumentNullException("There were no word founded");
            }
            return idWord;
        }
    }
}
