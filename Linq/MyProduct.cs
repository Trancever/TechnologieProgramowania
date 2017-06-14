using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class MyProduct : Product
    {
        public MyProduct(Product product)
        {
            this.Name = product.Name;
            this.ProductID = product.ProductID;
            this.ProductReviews = product.ProductReviews;
        }
    }
}
