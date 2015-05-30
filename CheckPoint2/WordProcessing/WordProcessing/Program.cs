using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFromFile = "";
           
            Text text = Parser.CreateText("text.txt", System.Text.Encoding.Default);
            //Text text = new Text(textFromFile);

            Console.WriteLine("1.все предложения в порядке возрастания количества слов в каждом из них");
            text.OrderBy(x => x.CountWord).ForAll(x => String.Format("{0} {1}",x.CountWord, x.ToString()));
            Console.WriteLine("*************************************************************************");


            Console.WriteLine("2.Во всех вопросительных предложениях текста найти и напеча¬тать без повторений слова заданной длины");
            int razmer = 5;
            text.SelectWord(razmer, TypeSentences.Interrogative).ForAll(x=>x.Value);
            Console.WriteLine("*************************************************************************");

            Console.WriteLine("3.Из текста удалить все слова заданной длины, начинающиеся на согласную букву.");
            text.RemoveWords(razmer, false);
            text.ForAll(x => x.ToString());
            Console.WriteLine("*************************************************************************");
            
            Console.WriteLine("4. В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой"+ 
            "может не совпадать с длиной слова");
            Text substring =Parser.CreateText("blabla");
            text = Parser.CreateText("text.txt", System.Text.Encoding.Default);
            text[0].ReplaceWordSubstring(x => x.Count == razmer, substring[0]);
            Console.WriteLine(text[0].ToString());
           
            Console.ReadLine();
        }
    }
}
