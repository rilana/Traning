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
        }
    }
}
