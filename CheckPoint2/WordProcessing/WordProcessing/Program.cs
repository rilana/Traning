﻿using System;
using System.Linq;

namespace WordProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var text = Parser.CreateText("text.txt", System.Text.Encoding.Default);
           

            Console.WriteLine("1.все предложения в порядке возрастания количества слов в каждом из них");
            text.OrderBy(x => x.CountWord).ForAll(x => String.Format("{0} {1}",x.CountWord, x.ToString()));
            Console.WriteLine("*************************************************************************");


            Console.WriteLine("2.Во всех вопросительных предложениях текста найти и напеча¬тать без повторений слова заданной длины");
            var razmer = 5;
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
