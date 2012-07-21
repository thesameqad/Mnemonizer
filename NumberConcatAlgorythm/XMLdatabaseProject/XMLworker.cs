using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using System.Xml;

namespace XMLdatabaseProject
{
    public class XMLworker
    {
        private XDocument dictionary;// = Assembly.GetEntryAssembly().GetManifestResourceStream("XMLdatabaseProject.xml");

        public XMLworker()
        {
            Stream file = Assembly.GetExecutingAssembly().GetManifestResourceStream("XMLdatabaseProject.Dictionary.xml");
            dictionary = XDocument.Load(file);
        }

        public string GetWordById(int id)
        {
            string word = (string)(from w in dictionary.Root.Elements("Words")
                                   where (int)w.Element("ID") == id
                                   select w.Element("word")
                           ).ToArray()[0];
            return word;
        }

        public int GetWordsCount()
        {
            int count = (from w in dictionary.Root.Elements("Words")
                          select w.Element("ID")
                         ).Count();
            return count;
        }

        public int GetIdForWord(string word)
        {
            int idWord = (int)(from w in dictionary.Root.Elements("Words")
                               where Equals((string)w.Element("word"), word)
                               select w.Element("ID")
                         ).ToArray()[0];
            return idWord;
        }
    }
}
