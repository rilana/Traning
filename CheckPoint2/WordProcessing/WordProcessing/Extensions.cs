using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordProcessing
{
    public  static class Extensions
    {
        public static IEnumerable<T> ForAll<T>(this IEnumerable<T> iterator,Func<T, string> convertToString)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(convertToString(item));
            }
            return iterator;
        }
    }
}
