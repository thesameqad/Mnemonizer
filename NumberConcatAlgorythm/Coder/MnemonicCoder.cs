using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataWorker;
using System.Numerics;
using Coder.DBServiceReference;

namespace Coder
{
    public class MnemonicCoder
    {
        private DataConnection dataConnector = new DataConnection();
        //private WCF_DataAccess.DbService dbService = new WCF_DataAccess.DbService();
        //private DataBaseService.DbServiceClient dataService = new DataBaseService.DbServiceClient();
        //private DataBaseService.DbServiceClient dataService;

        public MnemonicCoder()
        {
           // dataService = new DataBaseService.DbServiceClient();
        }


        public string coding (string enterString)
        {

            //dataService = new DataBaseService.DbServiceClient();
            //dataService.Open();
          

            //mnemonic string
            string MnemonicString = "";
            //numeric code of word (string format)
            string code = "";
            //numeric code of word (intager format)
            BigInteger NumericCode = new BigInteger();           

            //total lenght of dictionary
            ulong countWordsInDictionary = dataConnector.getCountOfRows();
                
            for (int i = 0; i < enterString.Length; i++)
                code += (int)enterString[i]-33;

            NumericCode = BigInteger.Parse(code);
           
            //remainder of dividing
            BigInteger ModOfDivCode = 0;

            using (var client = new DbServiceClient())
            {
                client.Open();
                do
                {
                    NumericCode = BigInteger.DivRem(NumericCode, countWordsInDictionary, out ModOfDivCode);
                    //Get word by number. Number equals integral part of the division
                    //MnemonicString += dataConnector.getWordByNumber((ulong)ModOfDivCode);

                    
                    MnemonicString += client.GetWord((int)ModOfDivCode);
                    


                    //DataBaseService.DbServiceClient dataService = new DataBaseService.DbServiceClient();
                    //MnemonicString += dataService.GetWord((int)ModOfDivCode);
                    MnemonicString += " ";
                }
                while (NumericCode != 0);
                client.Close();
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

            //total lenght of dictionary
            ulong countWordsInDictionary = dataConnector.getCountOfRows();


            //DataBaseService.DbServiceClient dbService = new DataBaseService.DbServiceClient();
            for (int i = N-1; i >= 0; i--)
            {
                if (words[i] != "")
                {
                   // DataBaseService.DbServiceClient dataService = new DataBaseService.DbServiceClient();
                   // NumericCode += dataService.GetId(words[i]) * BigInteger.Pow(countWordsInDictionary, i);
                    //  NumericCode += dataConnector.getWordId(words[i]) * BigInteger.Pow(countWordsInDictionary, i);
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
