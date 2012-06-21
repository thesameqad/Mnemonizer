using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Windows.Forms;
using DataWorker;

namespace Coder
{
    public class MnemonicCoder
    {
        public IDataWorker DataWorker { get; set; }
        public bool IsError { set; get; }

        public string GetMnemonicString (string enterString)
        {
            IsError = false;
            //mnemonic string
            string mnemonicString = "";
            //numeric code of word (string format)
            string code = "";
            //numeric code of word (intager format)
            BigInteger numericCode = new BigInteger();
            int countWordsInDictionary = DataWorker.GetWordsCount();

                for (int i = 0; i < enterString.Length; i++)
                {
                    //if we have code < 10 (0,1,...,9), we add to code 00,01,...,09
                    int tempCode = (int)enterString[i] - 32;
                    if (tempCode < 10)
                        code += 0;
                    code += tempCode;
                }

                numericCode = BigInteger.Parse(code);

                //remainder of dividing
                BigInteger modOfDivCode = 0;

                do
                {
                    try
                    {
                        numericCode = BigInteger.DivRem(numericCode, countWordsInDictionary, out modOfDivCode);
                        //Get word by number. Number equals integral part of the division
                        mnemonicString += DataWorker.GetWordById((int)modOfDivCode);
                        mnemonicString += " ";
                    }
                    catch (ArgumentNullException ex)
                    {
                        IsError = true;
                        throw ex;
                    }
                    catch (Exception)
                    {
                        IsError = true;
                        throw new Exception("Unexpected exception");
                    }

                }
                while (numericCode != 0);

            return mnemonicString;
        }

        public string GetOriginalString (string mnemonicString)
        {
            IsError = false;

            //result string, result of decoding
            string resultString = "";

            //array of words which are in mnemonic string
            string [] words = mnemonicString.Split(' ');

            //delete spaces from string
            words = (from w in words
                     where Equals(w, "") != true
                     select w).ToArray();
            //number of words in the mnemonic string
            int wordsCount = words.Length;
         
            //numeric code of mnemonic string
            BigInteger numericCode = 0;

            int countWordsInDictionary = DataWorker.GetWordsCount();

                for (int i = wordsCount - 1; i >= 0; i--)
                {
                    try
                    {
                        numericCode += DataWorker.GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary, i);//client.GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary, i);
                    }
                    catch (ArgumentNullException ex)
                    {
                        IsError = true;
                        throw ex;
                    }
                    catch (Exception)
                    {
                        IsError = true;
                        throw new Exception("Unexpected exception");
                    }
                }

            //code of simbol
            BigInteger codeOfSimbol = 0;

            if (IsError == false)
            {
                //get result string (decoding)
                while (numericCode != 0)
                {
                    numericCode = BigInteger.DivRem(numericCode, 100, out codeOfSimbol);
                    resultString += (char)((ulong)codeOfSimbol + 32);
                }

                //resultString containes result, but letters are in reverse order
                //get reverse resultString
                string tempString = resultString;
                resultString = "";
                for (int i = tempString.Length - 1; i >= 0; i--)
                    resultString += tempString[i];
            }

            return resultString;
        }
    }
}
