using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FindString
{
    public class findString
    {                
        public List<Word> faundInDB(String text)
        {
            List<Word> result = null;
            String query = @"select * from Dictionary.dbo.Words where Dictionary.dbo.Words.word like '" + text + "%'";
            DictionaryDataContext connect = new DictionaryDataContext();
            result = connect.ExecuteQuery<Word>(query).ToList();
            return result;
        }
        public string FaundInDB(String text)
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
