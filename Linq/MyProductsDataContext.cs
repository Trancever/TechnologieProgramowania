using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class MyProductsDataContext : IDataContext
    {
        private List<object> _objects;

        public MyProductsDataContext(List<Product> products, List<ProductReview> reviews)
        {
            _objects = new List<object>();
            foreach (Product product in products)
            {
                _objects.Add(new MyProduct(product));
            }
            foreach (ProductReview review in reviews)
            {
                _objects.Add(review);
            }
        }

        public IQueryable<T> Repository<T>() where T : class
        {
            var result = from objects in _objects
                where objects is T
                select objects;

            return result.Select(o => (T) o).AsQueryable();
        }

        public void Insert<T>(T item) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T item) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void SubmitChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}