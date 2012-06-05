using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataWorker;

namespace Coder
{
    public class MnemonicCoder
    {
        DataConnection dataConnector = new DataConnection();

        public string coding (string enterString)
        {
            //мнемоническая строка (результат кодировки)
            string mnemonicString = "";
            //код кодируемого слова в цифрах
            string code = "";
            //числовой код слова
            ulong numerCode = 0;

            //общее количество слов в словаре
            ulong countWordsInDictionary = dataConnector.getCountOfRows();
                
            for (int i = 0; i < enterString.Length; i++)
                code += (int)enterString[i]-33;

            //преобразуем в число
            for (int i = 0; i < code.Length; i++)
                numerCode += (ulong)((code[i] - 48) * Math.Pow(10 ,(code.Length - i - 1)));

            //целая часть от деления numerCode на countWordsInDictionary
            ulong integralPart;
            //остаток от деления numerCode на countWordsInDictionary
            ulong mod;

            do
            {
                integralPart = numerCode / countWordsInDictionary;
                mod = numerCode % countWordsInDictionary;

                mnemonicString += dataConnector.getWordByNumber(mod);
                mnemonicString += " ";

                numerCode = integralPart;
            }
            while (integralPart != 0);

           // mnemonicString = code;
            return mnemonicString;
        }

        public string decoding(string mnemonicString)
        {
            //результирующая строка (результат раскодирования)
            string resultString = "";

            //массив слов, которые находтся в  мнемонической строке
            string [] words = mnemonicString.Split(' ');
            //количество слов в мнемонической строке
            int N = words.Length;

            //числовой код
            ulong code = 0;
            //общее количество слов в словаре
            ulong countWordsInDictionary = dataConnector.getCountOfRows();

            for (int i = N-1; i >= 0; i--)
            {      
                if(words[i] !="")
                    code += dataConnector.getWordId(words[i]) * (ulong)Math.Pow(countWordsInDictionary, i);
            }

            //код символа
            ulong codeOfSimbol;

            while (code != 0)
            {
                //получаем по 2 цифры, начиная с конца кода
                codeOfSimbol = code % 100;
                code = code / 100;

                resultString += (char)(codeOfSimbol + 33);
            }

            //resultString - хранит результат, только в символы расположены в обратном порядке
            //получаем реверс строки resultString
            string tempString = resultString;
            int lenstr = tempString.Length;
            resultString = "";
            for (int i = lenstr-1; i >= 0; i--)
                resultString += tempString[i];

            return resultString;
        }
    }
}
