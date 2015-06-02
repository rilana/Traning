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
            var forAll = iterator as IList<T> ?? iterator.ToList();
            foreach (var item in forAll)
            {
                Console.WriteLine(convertToString(item));
            }
            return forAll;
        }
    }
}
