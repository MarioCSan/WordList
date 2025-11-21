using System;
using System.Reflection;
using WordListProcessor;
class Program
{
    static void Main(string[] args)
    {
        string filePath = Path.Combine(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..")), "Files", "wordlist.txt");

        var processor = new WordProcessor(filePath);
        var rs = processor.FindSixLetterCompoundWords();
        processor.PrintResults(rs);
    }
}