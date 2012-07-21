using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Windows.Forms;
using DataWorker;
<<<<<<< HEAD
using DataWorker.XmlDataWorker;
=======
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03

namespace Coder
{

    public class MnemonicCoder
    {
<<<<<<< HEAD

        private IDataWorker[] dataWorker;
        private int[] countWordsInDictionary;

        public bool IsError { set; get; }

        public MnemonicCoder()
        {
            dataWorker = new XmlDataWorker[2];
            dataWorker[0] = new XmlDataWorker("DataWorker.XmlDataWorker.DictionaryAdjectives.xml");
            dataWorker[1] = new XmlDataWorker("DataWorker.XmlDataWorker.DictionaryNouns.xml");

            countWordsInDictionary = new int[2];
            countWordsInDictionary[0] = dataWorker[0].GetWordsCount();
            countWordsInDictionary[1] = dataWorker[1].GetWordsCount();

        }
=======
        public IDataWorker DataWorker { get; set; }
        public bool IsError { set; get; }
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03

        public string GetMnemonicString (string enterString)
        {
            IsError = false;
            //mnemonic string
            string mnemonicString = "";
            //numeric code of word (string format)
            string code = "";
            //numeric code of word (intager format)
            BigInteger numericCode = new BigInteger();
<<<<<<< HEAD
            //int countWordsInDictionary = nounsDataWorker.GetWordsCount();//DataWorker.GetWordsCount();
=======
            int countWordsInDictionary = DataWorker.GetWordsCount();
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03

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
<<<<<<< HEAD
                
=======
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03

                int index = 0;
                do
                {
                    try
                    {
<<<<<<< HEAD
                        numericCode = BigInteger.DivRem(numericCode, countWordsInDictionary[index], out modOfDivCode);
                        //Get word by number. Number equals integral part of the division
                        mnemonicString += dataWorker[index].GetWordById((int)modOfDivCode);//DataWorker.GetWordById((int)modOfDivCode);
                        mnemonicString += " ";
                        index = 2 - (index + 1);
=======
                        numericCode = BigInteger.DivRem(numericCode, countWordsInDictionary, out modOfDivCode);
                        //Get word by number. Number equals integral part of the division
                        mnemonicString += DataWorker.GetWordById((int)modOfDivCode);
                        mnemonicString += " ";
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03
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

<<<<<<< HEAD

=======
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03
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
<<<<<<< HEAD

            //int countWordsInDictionary = nounsDataWorker.GetWordsCount();//DataWorker.GetWordsCount();


            int index;
            if (wordsCount % 2 == 0)
                index = 1;
            else
                index = 0;


                for (int i = wordsCount - 1; i >= 0; i--, index = 2 - (index + 1))
                {
                    try
                    {
                        //numericCode += dataWorker[index].GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary[index], i);//DataWorker.GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary, i);//client.GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary, i);
                       
                        int degreeOfNumber = i / 2;
                        if (i % 2 != 0)                           
                            degreeOfNumber += 1;

                        numericCode += dataWorker[index].GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary[0], degreeOfNumber) * BigInteger.Pow(countWordsInDictionary[1], i / 2);
=======

            int countWordsInDictionary = DataWorker.GetWordsCount();

                for (int i = wordsCount - 1; i >= 0; i--)
                {
                    try
                    {
                        numericCode += DataWorker.GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary, i);//client.GetIdForWord(words[i]) * BigInteger.Pow(countWordsInDictionary, i);
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03
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
