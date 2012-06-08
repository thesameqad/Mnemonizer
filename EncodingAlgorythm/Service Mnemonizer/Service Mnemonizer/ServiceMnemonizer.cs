using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service_Mnemonizer
{
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]  
  public class ServiceMnemonizer:IServiceMnemonizer
  {
      
      public String mnemoCode(String text)
      {
            String result = "";
            String tmp = "";
            String cur;
            String res = "";
            int start = 0;
            int end;          
            
            while (start < text.Length)
            {
                end = start ;
                while (end < text.Length)
                {
                    tmp = copy(start, end, text);                    
                    cur = ListWords(tmp)[0];
                    
                    if (cur == "" )
                        break; 
                    res = cur;
                    end++;
                }
                result += res + " ";
                start = end;
            }

            return result;
      }

      public string mnemogetdecode(string text)
      {
           string resultCode = "";            
            foreach (char s in text)
            {
                switch (s)
                {
                    case 'd':  resultCode += "0";  break;
                    case 'f':  resultCode += "1";  break;
                    case 'g':  resultCode += "2";  break;
                    case 'h':  resultCode += "3";  break;
                    case 'v':  resultCode += "4";  break;
                    case 'b':  resultCode += "5";  break;
                    case 'n':  resultCode += "6";  break;
                    case 'm':  resultCode += "7";  break;
                    case 'r':  resultCode += "8";  break;
                    case 't':  resultCode += "9";  break;
                }
            }
            return resultCode ;
      }
      private List<string> ListWords(String text)
      {
          List<string> result = null;
          DictionaryDataContext connect = new DictionaryDataContext();
          result = (from cust in connect.Words
                    where cust.code == text
                    select cust.word).ToList<string>();
          if (result.Count > 0)
                    return result;
          else
            {   
                  result = new List<string>();
                  result.Add("");
                  return result;
            }
      }
      private String copy(int from, int to, String text)
      {
          String cur = "";
          for (int i = from; i <= to; i++)
              cur += text[i];
          return cur;
      }
  }
}
