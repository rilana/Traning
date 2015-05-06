using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public class CatalogProduct:ICollection<IProduct>
    {
        private ICollection<IProduct> catalogProduct = new List<IProduct>();
        public void Add(IProduct item)
        {
            catalogProduct.Add(item);
        }

        public void Clear()
        {
            catalogProduct.Clear();
        }

        public bool Contains(IProduct item)
        {
            return catalogProduct.Contains(item);
        }

        public void CopyTo(IProduct[] array, int arrayIndex)
        {
            catalogProduct.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return catalogProduct.Count(); }
        }

        public bool IsReadOnly
        {
            get {return catalogProduct.IsReadOnly; }
        }

        public bool Remove(IProduct item)
        {
            return catalogProduct.Remove(item);
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return catalogProduct.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerable<IProduct> GetCatalogProduct(DateTime startDate, DateTime endDate)
        {
            foreach (var item in catalogProduct)
            {
                if (item.CreationDate >= startDate && item.CreationDate <= endDate)
                {
                    yield return item;
                }
            }
        }
        public void SortShelfLife()
        {

            var newList = catalogProduct.OrderBy(x => x.ShelfLife.TotalHours).ToList<IProduct>();
            catalogProduct = newList;
        }
        public void SortRating()
        {

            var newList = catalogProduct.OrderByDescending(x => x.Rating).ToList<IProduct>();
            catalogProduct = newList;
        }
        
    }
}
