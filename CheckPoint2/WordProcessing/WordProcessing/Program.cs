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
            Console.ReadLine();
        }
    }
}
