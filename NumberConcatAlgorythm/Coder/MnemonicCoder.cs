using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DataWorker;
using System.Numerics;
//using SimpleDatabaseProject;
//using Coder.DataBaseService;

namespace Coder
{
    public class MnemonicCoder
    {
        //private DataConnection dataConnector = new DataConnection();

       /* public void fillTable()
        {
            LocalDataConnector LocalConnector = new LocalDataConnector();
            Array arr = dataConnector.getAllWords();
            foreach (string word in arr)
            {
                LocalConnector.insertToTable(word);
            }
        }*/


        public string coding (string enterString)
        {

            //mnemonic string
            string MnemonicString = "";
            //numeric code of word (string format)
            string code = "";
            //numeric code of word (intager format)
            BigInteger NumericCode = new BigInteger();


            using (DictionaryServiceReference.DictionaryServiceClient client = new DictionaryServiceReference.DictionaryServiceClient())
            {

                //total lenght of dictionary
                int countWordsInDictionary = client.GetWordsCount(); //dataConnector.getCountOfRows();

                for (int i = 0; i < enterString.Length; i++)
                    code += (int)enterString[i] - 33;

                NumericCode = BigInteger.Parse(code);

                //remainder of dividing
                BigInteger ModOfDivCode = 0;

                // DbServiceClient client = new DbServiceClient();

                do
                {

                    NumericCode = BigInteger.DivRem(NumericCode, countWordsInDictionary, out ModOfDivCode);
                    //Get word by number. Number equals integral part of the division
                    MnemonicString += client.GetWordById((int)ModOfDivCode); //dataConnector.getWordByNumber((ulong)ModOfDivCode);
                    
                    MnemonicString += " ";
                }
                while (NumericCode != 0);
            }

            return MnemonicString;
        }

        public string decoding(string mnemonicString)
        {
            //result string, result of decoding
            string resultString = "";

            //array of words which are in mnemonic string
            string [] words = mnemonicString.Split(' ');
            //number of words in the mnemonic string
            int N = words.Length;

            //numeric code of mnemonic string
            BigInteger NumericCode = 0;

            using (DictionaryServiceReference.DictionaryServiceClient client = new DictionaryServiceReference.DictionaryServiceClient())
            {

                //total lenght of dictionary
                int countWordsInDictionary = client.GetWordsCount();


                //DataBaseService.DbServiceClient dbService = new DataBaseService.DbServiceClient();
                for (int i = N - 1; i >= 0; i--)
                {
                    if (words[i] != "")
                    {
                        NumericCode += client.GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary, i);
                        //NumericCode += dataConnector.getWordId(words[i]) * BigInteger.Pow(countWordsInDictionary, i);
                    }
                }
            }

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
