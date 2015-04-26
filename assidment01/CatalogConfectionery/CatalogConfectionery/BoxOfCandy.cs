using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public class BoxOfCandy:Product,IGramm,ICollection<Stuffing>
    {
        private ICollection<Stuffing> stuffings=new List<Stuffing>();
        public int Gramm
        {
            get;
            set;
        }

        public void Add(Stuffing item)
        {
            stuffings.Add(item);

        }

        public void Clear()
        {
            stuffings.Clear();
        }

        public bool Contains(Stuffing item)
        {
            return stuffings.Contains(item);
        }

        public void CopyTo(Stuffing[] array, int arrayIndex)
        {
           stuffings.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return stuffings.Count(); }
        }

        public bool IsReadOnly
        {
            get { return stuffings.IsReadOnly; }
        }

        public bool Remove(Stuffing item)
        {
            return stuffings.Remove(item);
        }

        public IEnumerator<Stuffing> GetEnumerator()
        {
            return stuffings.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
