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
            sw.Stop();
            return resultCode += "  (" + sw.ElapsedMilliseconds + "/ms)";
        }
        
    }
}
