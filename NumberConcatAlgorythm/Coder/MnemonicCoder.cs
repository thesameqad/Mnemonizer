using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Coder
{
    public class MnemonicCoder
    {
        //private SampleDatabaseProject.LocalDataConnector client = new SampleDatabaseProject.LocalDataConnector();
        //private DataWorker.DataConnection client = new DataWorker.DataConnection();
        private XMLdatabaseProject.XMLworker client = new XMLdatabaseProject.XMLworker();

        /*private string ErrorLog = "";
        public bool isError { set; get; }*/

        public string GetMnemonicString (string enterString)
        {
            //isError = false;

          //  XMLdatabaseProject.XMLworker worker = new XMLdatabaseProject.XMLworker();
            //mnemonic string
            string MnemonicString = "";
            //numeric code of word (string format)
            string code = "";
            //numeric code of word (intager format)
            BigInteger NumericCode = new BigInteger();

           // using (DictionaryServiceReference.DictionaryServiceClient client = new DictionaryServiceReference.DictionaryServiceClient())
            //{

                //total lenght of dictionary
            int countWordsInDictionary = client.GetWordsCount();//client.getCountOfRows();

                for (int i = 0; i < enterString.Length; i++)
                {
                    //if we have code < 10 (0,1,...,9), we add to code 00,01,...,09
                    int tempCode = (int)enterString[i] - 33;
                    if (tempCode < 10)
                        code += 0;
                    code += tempCode;
                }

                NumericCode = BigInteger.Parse(code);

                //remainder of dividing
                BigInteger ModOfDivCode = 0;

                do
                {
                    NumericCode = BigInteger.DivRem(NumericCode, countWordsInDictionary, out ModOfDivCode);
                    //Get word by number. Number equals integral part of the division
                    MnemonicString += client.GetWordById((int)ModOfDivCode);//client.getWordByNumber((int)ModOfDivCode);
                    MnemonicString += " ";
                }
                while (NumericCode != 0);
           // }

            return MnemonicString;
        }

        public string GetOriginalString (string mnemonicString)
        {
            //result string, result of decoding
            string resultString = "";

            //array of words which are in mnemonic string
            string [] words = mnemonicString.Split(' ');
            //number of words in the mnemonic string
            int N = words.Length;

            //numeric code of mnemonic string
            BigInteger NumericCode = 0;

            //using (DictionaryServiceReference.DictionaryServiceClient client = new DictionaryServiceReference.DictionaryServiceClient())
            //{

                //total lenght of dictionary
            int countWordsInDictionary = client.GetWordsCount();//client.getCountOfRows();

                for (int i = N - 1; i >= 0; i--)
                    if (words[i] != "")
                    {
                        //int CodeOfWord = client.GetIdForWord(words[i]);
                        NumericCode += client.GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary, i);//client.getWordId(words[i]) * BigInteger.Pow(countWordsInDictionary, i);
                    }
           // }

            //code of simbol
            BigInteger CodeOfSimbol = 0;

            //get result string (decoding)
            while (NumericCode != 0)
            {
                NumericCode = BigInteger.DivRem(NumericCode, 100, out CodeOfSimbol);
                resultString += (char)((ulong)CodeOfSimbol + 33);
            }

            //resultString containes result, but letters are in reverse order
            //get reverse resultString
            string tempString = resultString;
            int lenstr = tempString.Length;
            resultString = "";
            for (int i = lenstr-1; i >= 0; i--)
                resultString += tempString[i];

            return resultString;
        }
    }
}
