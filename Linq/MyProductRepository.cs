using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class MyProductRepository
    {
        private readonly IDataContext iDataContext;

        public MyProductRepository(IDataContext context)
        {
            iDataContext = context;
        }

        public IList<MyProduct> GetProductsByName(string productName)
        {
            IEnumerable<MyProduct> result = from product
                                         in iDataContext.Repository<MyProduct>()
                                         where product.Name == productName
                                         select product;

            return result.ToList();
        }

        public IList<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            IQueryable<MyProduct> result = from p
                                           in iDataContext.Repository<MyProduct>()
                                           where p.ProductReviews.Count == howManyReviews
                                           select p;

            return result.ToList();
        }

        public List<MyProduct> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            IQueryable<MyProduct> result = (from p
                                         in iDataContext.Repository<MyProduct>()
                                         join pr in iDataContext.Repository<ProductReview>()
                                         on p.ProductID equals pr.ProductID
                                         orderby pr.ReviewDate descending
                                         select p).Distinct().Take(howManyProducts);

            return result.ToList();
        }
    }
}
