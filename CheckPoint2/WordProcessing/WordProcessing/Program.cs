using System;
using System.Linq;

namespace WordProcessing
{
    class Program
    {
        static void Main(string[] args)
        {

            var text = Parser.CreateText("text.txt", System.Text.Encoding.Default);
           

            Console.WriteLine("1.");
            text.OrderBy(x => x.CountWord).ForAll(x => string.Format("{0} {1}",x.CountWord, x.ToString()));
            Console.WriteLine("*************************************************************************");


            Console.WriteLine("2.");
            var razmer = 5;
            text.SelectWord(razmer, TypeSentences.Interrogative).ForAll(x=>x.Value);
            Console.WriteLine("*************************************************************************");

            Console.WriteLine("3.");
            text.RemoveWords(razmer, false);
            text.ForAll(x => x.ToString());
            Console.WriteLine("*************************************************************************");
            
            Console.WriteLine("4.");
            var substring =Parser.CreateText("bla bla");
            text = Parser.CreateText("text.txt", System.Text.Encoding.Default);
            text[0].ReplaceWordSubstring(x => x.Count == razmer, substring[0]);
            Console.WriteLine(text[0].ToString());
           
            Console.ReadLine();
        }
    }
}
