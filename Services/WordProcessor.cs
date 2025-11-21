using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using wordlist.Models; 


namespace WordListProcessor
{
    public class WordProcessor
    {
        private List<string> wordList;

        public WordProcessor(string filePath)
        {
            wordList = new List<string>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string word = line.Trim().ToLower();
                wordList.Add(word);
            }

        }

        public List<Word> FindSixLetterCompoundWords()
        {
            var result = new List<Word>();

            foreach (var word in wordList)
            {
                if (word.Length != 6) continue;

                for (int i = 1; i < 6; i++)
                {
                    string firstPart = word.Substring(0, i);
                    string secondPart = word.Substring(i, 6 - i);

                    if (wordList.Contains(firstPart) && wordList.Contains(secondPart))
                    {
                        Word cw = new Word()
                        {
                            First = firstPart,
                            Second = secondPart,
                            Full = word
                        };

                        result.Add(cw);
                        break;
                    }
                }
            }

            return result;
        }

        public void PrintResults(List<Word> rs)
        {
            foreach (var item in rs)
            {
                Console.WriteLine($"{item.First} + {item.Second} => {item.Full}");
            }
        }
    }
}