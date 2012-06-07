using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindString;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CodeString
{
    public class codeString
    {
        private findString FS;        
        private String copy(int from, int to, String text)
        {
            String cur = "";
            for (int i = from; i <= to; i++)
                cur += text[i];
            return cur;
        }
        public String mnemoCode(String text)
        {
            String result = "";
            String tmp = "";
            String cur;
            String res = "";
            int start = 0;
            int end;
            FS = new findString();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (start < text.Length)
            {
                end = text.Length-1;
                while (end >= start)
                {

                   /* if ((text.Length - end) == 1)
                        cur = FS.word(text[end].ToString());
                    else
                    {*/
                        tmp = copy(start, end, text);
                        cur = FS.word(tmp);
                   // }

                    if (cur != "")
                    { end++; res = cur; break; }               
                    end--;
                    
                }
                result += res + " ";
                if( end == text.Length)
                    break;
                start = end;
            }
            sw.Stop();
            return result += "  (" + sw.ElapsedMilliseconds + "/ms)";
        }       
    }
}
