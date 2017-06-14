using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class ProductsRepository
    {
        private readonly IDataContext iDataContext;

        public ProductsRepository(IDataContext context)
        {
            iDataContext = context;
        }

        public IList<Product> GetProductsByName(string productName)
        {
            IQueryable<Product> result = from product
                                         in iDataContext.Repository<Product>()
                                         where product.Name == productName
                                         select product;

            return result.ToList();
        }

        public IList<Product> GetProducts()
        {
            IQueryable<Product> result = from product in iDataContext.Repository<Product>()
                select product;

            return result.ToList();
        }

        public void DeleteProduct(Product product)
        {
            iDataContext.Delete<Product>(product);
            iDataContext.SubmitChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product entity = iDataContext.Repository<Product>().First(e => e.ProductID == product.ProductID);
            entity.Name = product.Name;
            entity.ProductNumber = product.ProductNumber;
            entity.Color = product.Color;
            entity.SafetyStockLevel = product.SafetyStockLevel;
            entity.ReorderPoint = product.ReorderPoint;
            entity.StandardCost = product.StandardCost;
            entity.ListPrice = product.ListPrice;
            entity.Size = product.Size;
            entity.SizeUnitMeasureCode = product.SizeUnitMeasureCode;
            entity.WeightUnitMeasureCode = product.WeightUnitMeasureCode;
            entity.Weight = product.Weight;
            entity.DaysToManufacture = product.DaysToManufacture;
            entity.ProductLine = product.ProductLine;
            entity.Class = product.Class;
            entity.Style = product.Style;
            entity.ProductSubcategoryID = product.ProductSubcategoryID;
            entity.ProductModelID = product.ProductModelID;
            entity.SellStartDate = product.SellStartDate;
            entity.SellEndDate = product.SellEndDate;
            entity.DiscontinuedDate = product.DiscontinuedDate;
            entity.ModifiedDate = product.ModifiedDate;
            iDataContext.SubmitChanges();
        }

        public void AddProduct(Product product)
        {
            iDataContext.Insert(product);
            iDataContext.SubmitChanges();
        }

        public IList<Product> GetProductByVendorName(string vendorName)
        {
            IQueryable<Product> result = from p
                                         in iDataContext.Repository<Product>()
                                         join pv in iDataContext.Repository<ProductVendor>()
                                         on p.ProductID equals pv.ProductID
                                         join v in iDataContext.Repository<Vendor>()
                                         on pv.BusinessEntityID equals v.BusinessEntityID
                                         where v.Name == vendorName
                                         select p;

            return result.ToList();
        }

        public List<string> GetProductNamesByVendorName(string vendorName)
        {
            IQueryable<string> result = from p
                                        in iDataContext.Repository<Product>()
                                        join pv in iDataContext.Repository<ProductVendor>()
                                        on p.ProductID equals pv.ProductID
                                        join v in iDataContext.Repository<Vendor>()
                                        on pv.BusinessEntityID equals v.BusinessEntityID
                                        where v.Name == vendorName
                                        select p.Name;

            return result.ToList();
        }

        public string GetProductVendorByProductName(string productName)
        {
            IQueryable<string> result = from v
                                        in iDataContext.Repository<Vendor>()
                                        join pv in iDataContext.Repository<ProductVendor>()
                                        on v.BusinessEntityID equals pv.BusinessEntityID
                                        join p in iDataContext.Repository<Product>()
                                        on pv.ProductID equals p.ProductID
                                        where p.Name == productName
                                        select v.Name;

            return result.FirstOrDefault();
        }

        public List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            IQueryable<Product> result = from p
                                         in iDataContext.Repository<Product>()
                                         where p.ProductReviews.Count == howManyReviews
                                         select p;
                                          
            return result.ToList();
        }

        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            IQueryable<Product> result = (from p
                                          in iDataContext.Repository<Product>()
                                          join pr in iDataContext.Repository<ProductReview>()
                                          on p.ProductID equals pr.ProductID
                                          orderby pr.ReviewDate descending
                                          select p).Distinct().Take(howManyProducts);

            return result.ToList();
        }

        public List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            IQueryable<Product> result = (from p
                                          in iDataContext.Repository<Product>()
                                          join sc in iDataContext.Repository<ProductSubcategory>()
                                          on p.ProductSubcategoryID equals sc.ProductSubcategoryID
                                          join s in iDataContext.Repository<ProductCategory>()
                                          on sc.ProductCategoryID equals s.ProductCategoryID
                                          where s.Name == categoryName
                                          orderby s.Name, p.Name ascending
                                          select p).Take(n);

            return result.ToList();
        }

        public int GetTotalStandardCostByCategory(ProductCategory category)
        {
            int result = (from p
                          in iDataContext.Repository<Product>()
                          join sc in iDataContext.Repository<ProductSubcategory>()
                          on p.ProductSubcategoryID equals sc.ProductSubcategoryID
                          join s in iDataContext.Repository<ProductCategory>()
                          on sc.ProductCategoryID equals s.ProductCategoryID
                          where s.ProductCategoryID == category.ProductCategoryID
                          select p).Distinct().Sum(x => (int)x.StandardCost);

            return result;
        }
    }
}