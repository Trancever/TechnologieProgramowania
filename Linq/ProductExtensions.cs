using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq
{
    public static class ProductExtensions
    {
        public static List<Product> GetProductsWithNoCategoryAssigned(this List<Product> products)
        {
            return products.Where(x => x.ProductSubcategoryID == null).Select(x => x).ToList();
        }

        public static List<Product> GetProductsBySizeAndPage(this List<Product> products, int size, int page)
        {
            return products.Skip(page * size).Take(size).ToList();
        }

        // TODO: It's not done yet. Temporary push
        public static string GetProductsNameAndTheirVendorsNamesAsString(this List<Product> products)
        {
            StringBuilder str = new StringBuilder();

            var items = (from p in products
                        from v in p.ProductVendors
                        where p.ProductID == v.ProductID
                        select new {productName = p.Name, vendorName = v.Vendor.Name}).ToList();

            foreach (var item in items)
            {
                str.Append(item.productName + "," + item.vendorName + "\n");
            }

            return str.ToString();
        }

    }
}