using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FindString
{
    public class findString
    {
        public List<string> ListWords(String text)
        {
            List<string> result = null;           
            DictionaryDataContext connect = new DictionaryDataContext();
            result = (from cust in connect.Words
                      where cust.code == text
                      select cust.word1).ToList<string>();
            return result;
        }
        public string word(String text)
        {
            DictionaryDataContext connect = new DictionaryDataContext();
            List<string> result = (from cust in connect.Words
                                   where cust.code == text
                                   select cust.word1).ToList<string>();
            
            if (result.Count > 0)
                return result[0];
            else
                return "";
        }

    }
}
