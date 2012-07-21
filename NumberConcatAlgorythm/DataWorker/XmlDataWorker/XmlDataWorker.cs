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

<<<<<<< HEAD
        public XmlDataWorker(string fileName)
        {
            Stream file = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);
=======
        public XmlDataWorker()
        {
            Stream file = Assembly.GetExecutingAssembly().GetManifestResourceStream("DataWorker.XmlDataWorker.Dictionary.xml");
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03
            dictionary = XDocument.Load(file);
        }

        public string GetWordById(int id)
        {
            string word = (string)(from w in dictionary.Root.Elements("Words")
<<<<<<< HEAD
                                   where (int)w.Element("Id") == id
                                   select w.Element("Word")
=======
                                   where (int)w.Element("ID") == id
                                   select w.Element("word")
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03
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
<<<<<<< HEAD
                          select w.Element("Id")
=======
                          select w.Element("ID")
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03
                         ).Count();
            return count;
        }

        public int GetIdForWord(string word)
        {
            int idWord = (int)(from w in dictionary.Root.Elements("Words")
<<<<<<< HEAD
                               where Equals((string)w.Element("Word"), word)
                               select w.Element("Id")
=======
                               where Equals((string)w.Element("word"), word)
                               select w.Element("ID")
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03
                         ).FirstOrDefault();
            if (idWord <= 0)
            {
                throw new ArgumentNullException("There were no word founded");
            }
            return idWord;
        }
    }
}
