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
            string text = "";
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                text = sr.ReadToEnd();
            }

            ICollection<Sentence> listSentences = new List<Sentence>(Worker.ConstructSentencesList(text));

           //1.все предложения в порядке возрастания количества слов в каждом из них
            foreach (var item in listSentences.OrderBy(x => x.CountWord))
            {
                Console.WriteLine(item.CountWord + " " + item.Value);
               
            }
            Console.WriteLine("--------------------------------------------");
            //-----------------------------------------------------------

            //3.Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
            int razmer=5;
            foreach (var item in listSentences)
            {
                item.RemoveAll(x=>x.Count==5&&x[0].IsVowel==false); 
             
            }
           
        
          
            Console.WriteLine("--------------------------------------------");
            //-----------------------------------------------------------
            Console.ReadLine();
        }
    }
}
