using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindString;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DeCodeString
{
    public class deCodeString
    {
        private String text;
        private findString FS;

        private String copy(int from, int to, String text)
        {
            String cur = "";
            for (int i = from; i <= to; i++)
                cur += text[i];
            return cur;
        }
        public string mnemogetdecode(String text)
        {
            string resultCode = "";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (char s in text)
            {
                switch (s)
                {
                    case 'd':
                        resultCode += "0";
                        break;
                    case 'f':
                        resultCode += "1";
                        break;
                    case 'g':
                        resultCode += "2";
                        break;
                    case 'h':
                        resultCode += "3";
                        break;
                    case 'v':
                        resultCode += "4";
                        break;
                    case 'b':
                        resultCode += "5";
                        break;
                    case 'n':
                        resultCode += "6";
                        break;
                    case 'm':
                        resultCode += "7";
                        break;
                    case 'r':
                        resultCode += "8";
                        break;
                    case 't':
                        resultCode += "9";
                        break;
                }
            } 
            sw.Stop();
            return resultCode += "  (" + sw.ElapsedMilliseconds + "/ms)";
        }
        public String getdecode(String text)
        {
            String result = "";
            String tmp = "";
            Regex reg;
            List<Word> cur;
            List<Word> res = null;
            int start = 0;
            int end;
            FS = new findString();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (start < text.Length)
            {
                res = FS.faundInDB(text[start].ToString());
                end = start + 1;
                while (end < text.Length)
                {
                    tmp = copy(start, end, text);
                    end++;
                    cur = new List<Word>();
                    foreach (Word w in res)
                    {
                        reg = new Regex(@"^" + tmp + ".*", RegexOptions.None);
                        MatchCollection matches = reg.Matches(w.word1);
                        if (matches.Count > 0)
                            cur.Add(w);
                    }
                    if (cur.Count == 0)
                    {
                        end--;
                        break;
                    }
                    res = cur;
                }
                res.Sort(delegate(Word W1, Word W2)
                    { return W1.word1.CompareTo(W2.word1); });
                result = result + res[0].word1 + " ";
                start = end;
            }
            sw.Stop();
            return result += "  (" + sw.ElapsedMilliseconds + "/ms)";
         }
    }
}
