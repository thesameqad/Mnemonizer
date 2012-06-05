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
        private String copy(int to, String text)
        {
            String cur = "";
            for (int i = 0; i <= to; i++)
                cur += text[i];
            return cur;
        }
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
                end = start + 1;
                while (end < text.Length)
                {
                    tmp = copy(start, end, text);
                    end++;
                    cur = FS.FaundInDB(tmp);
                    if (text.Length % 2 != 0)
                    {
                        if (cur == "" || (text.Length - end) == 1)
                        {
                            end--;
                            break;
                        }
                    }
                    else
                        if (cur == "" )
                        {
                            end--;
                            break;
                        }
                        res = cur;
                }
                result += res + " ";
                start = end;
            }
            sw.Stop();
            return result += "  (" + sw.ElapsedMilliseconds + "/ms)";
        }
        public String Code(String text)// закодирование строки
        {
            String result = "";
            String tmp = "";
            List<Word> cur;
            List<Word> res = null;
            Regex reg;
            int end;
            FS = new findString();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            String[] TEXT = text.Split(' '); // разбиение на слова 

            foreach (String curword in TEXT) //проходим по всем словам
            {
                if (curword != "")
                {
                    res = FS.faundInDB(curword[0].ToString()); // запрашиваем слова из базы начинаюшееся на первую букву искомого слова
                    end = 0;
                    while (end < curword.Length) // пока не конец слова
                    {
                        tmp = copy(end, curword);  // переписываем часть слова с 0 по end символ слова
                        end++;
                        cur = new List<Word>();
                        foreach (Word w in res)//  обходим по области поика
                        {
                            reg = new Regex(@"^" + tmp + ".*", RegexOptions.None);//поиск  подстроки в 
                            MatchCollection matches = reg.Matches(w.word1);       // нашей текушей области слов
                            if (matches.Count > 0)                                //если совподают 
                                cur.Add(w);                                       // заносим в новую область поиска 
                        }
                        if (cur.Count != 0)
                        {
                            cur.Sort(delegate(Word W1, Word W2)        //сортировка области 
                            { return W1.word1.CompareTo(W2.word1); }); // в афавитном порядке
                            if (cur[0].word1 == curword)  // если верху списка наше кодируемое слово значет 
                            {
                                result += tmp;           //значет tmp это код  слова 
                                break;
                            }
                        }
                        res = cur;// уменьшаем область поиска 
                    }
                }
            }
            sw.Stop();
            return result += "  (" + sw.ElapsedMilliseconds + "/ms)";
        }
    }
}
