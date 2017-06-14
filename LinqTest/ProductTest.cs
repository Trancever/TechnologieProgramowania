using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Linq;
using Moq;

namespace LinqTest
{
    [TestClass]
    public class ProductTest
    {
        private Mock<IDataContext> iDataContext;

        [TestInitialize]
        public void initialize()
        {
            iDataContext = new Mock<IDataContext>();
            iDataContext.Setup(x => x.Repository<Product>()).Returns(GetProducts());
            iDataContext.Setup(x => x.Repository<Vendor>()).Returns(GetVendors());
            iDataContext.Setup(x => x.Repository<ProductVendor>()).Returns(GetProductVendors());
            iDataContext.Setup(x => x.Repository<ProductCategory>()).Returns(GetCategories());
            iDataContext.Setup(x => x.Repository<ProductSubcategory>()).Returns(GetSubcategories());
            iDataContext.Setup(x => x.Repository<ProductReview>()).Returns(GetReviews());
        }

        private IQueryable<Product> GetProducts()
        {
            Product product = new Product { Name = "Blade", ProductID = 1, ProductSubcategoryID = 1, StandardCost = 100, ProductReviews = GetReviewsForProduct(1) };
            Product product2 = new Product { Name = "Hat", ProductID = 2, ProductSubcategoryID = 2, StandardCost = 100, ProductReviews = GetReviewsForProduct(2) };
            Product product3 = new Product { Name = "Knife", ProductID = 3, ProductSubcategoryID = 1, StandardCost = 100, ProductReviews = GetReviewsForProduct(3) };
            Product product4 = new Product { Name = "Phone", ProductID = 4, ProductSubcategoryID = 2, StandardCost = 100, ProductReviews = GetReviewsForProduct(4) };
            Product product5 = new Product { Name = "Cup", ProductID = 5, ProductSubcategoryID = 2, StandardCost = 100, ProductReviews = GetReviewsForProduct(5) };
            Product product6 = new Product { Name = "Notebook", ProductID = 6, ProductSubcategoryID = 2, StandardCost = 100, ProductReviews = GetReviewsForProduct(6) };
            Product product7 = new Product { Name = "Headphones", ProductID = 7, ProductSubcategoryID = 2, StandardCost = 100, ProductReviews = GetReviewsForProduct(7) };
            Product product8 = new Product { Name = "Pen", ProductID = 8, ProductSubcategoryID = 2, StandardCost = 100, ProductReviews = GetReviewsForProduct(8) };
            Product product9 = new Product { Name = "Keyboard", ProductID = 9, ProductSubcategoryID = 2, StandardCost = 100, ProductReviews = GetReviewsForProduct(9) };

            List<Product> products = new List<Product>
            {
                product,
                product2,
                product3,
                product4,
                product5,
                product6,
                product7,
                product8,
                product9
            };

            return products.AsQueryable();
        }

        private IQueryable<ProductVendor> GetProductVendors()
        {
            ProductVendor pv  = new ProductVendor { ProductID = 1, BusinessEntityID = 1 };
            ProductVendor pv2 = new ProductVendor { ProductID = 2, BusinessEntityID = 2 };
            ProductVendor pv3 = new ProductVendor { ProductID = 3, BusinessEntityID = 4 };
            ProductVendor pv4 = new ProductVendor { ProductID = 4, BusinessEntityID = 3 };
            ProductVendor pv5 = new ProductVendor { ProductID = 5, BusinessEntityID = 2 };
            ProductVendor pv6 = new ProductVendor { ProductID = 6, BusinessEntityID = 1 };
            ProductVendor pv7 = new ProductVendor { ProductID = 7, BusinessEntityID = 3 };
            ProductVendor pv8 = new ProductVendor { ProductID = 8, BusinessEntityID = 2 };
            ProductVendor pv9 = new ProductVendor { ProductID = 9, BusinessEntityID = 4 };

            List<ProductVendor> pVendors = new List<ProductVendor>()
            {
                pv,
                pv2,
                pv3,
                pv4,
                pv5,
                pv6,
                pv7,
                pv8,
                pv9
            };


            return pVendors.AsQueryable();
        }

        private IQueryable<Vendor> GetVendors()
        {
            Vendor vendor = new Vendor { Name = "Microsoft", BusinessEntityID = 1 };
            Vendor vendor2 = new Vendor { Name = "Apple", BusinessEntityID = 2 };
            Vendor vendor3 = new Vendor { Name = "Samsung", BusinessEntityID = 3 };
            Vendor vendor4 = new Vendor { Name = "LG", BusinessEntityID = 4 };

            List<Vendor> vendors = new List<Vendor>
            {
                vendor,
                vendor2,
                vendor3,
                vendor4
            };

            return vendors.AsQueryable();
        }

        private IQueryable<ProductReview> GetReviews()
        {
            ProductReview review = new ProductReview { ProductID = 1, ReviewDate = DateTime.Now };
            ProductReview review2 = new ProductReview { ProductID = 2, ReviewDate = DateTime.Now.AddMonths(-1) };
            ProductReview review3 = new ProductReview { ProductID = 3, ReviewDate = DateTime.Now.AddMonths(-2) };
            ProductReview review4 = new ProductReview { ProductID = 4, ReviewDate = DateTime.Now.AddMonths(-3) };
            ProductReview review5 = new ProductReview { ProductID = 5, ReviewDate = DateTime.Now.AddMonths(-4) };
            ProductReview review6 = new ProductReview { ProductID = 6, ReviewDate = DateTime.Now.AddMonths(-5) };
            ProductReview review7 = new ProductReview { ProductID = 2, ReviewDate = DateTime.Now.AddMonths(-6) };
            ProductReview review8 = new ProductReview { ProductID = 3, ReviewDate = DateTime.Now.AddMonths(-7) };
            ProductReview review9 = new ProductReview { ProductID = 5, ReviewDate = DateTime.Now.AddMonths(-9) };
            ProductReview review10 = new ProductReview { ProductID = 7, ReviewDate = DateTime.Now.AddMonths(-10) };
            ProductReview review11 = new ProductReview { ProductID = 8, ReviewDate = DateTime.Now.AddMonths(-11) };
            ProductReview review12 = new ProductReview { ProductID = 9, ReviewDate = DateTime.Now.AddMonths(-12) };

            List<ProductReview> reviews = new List<ProductReview>()
            {
                review,
                review2,
                review3,
                review4,
                review5,
                review6,
                review7,
                review8,
                review9,
                review10,
                review11,
                review12,
            };

            return reviews.AsQueryable();
        }

        private EntitySet<ProductReview> GetReviewsForProduct(int ProductID)
        {
            var reviews = GetReviews().ToList();
            var result = new EntitySet<ProductReview>();
            foreach (ProductReview review in reviews)
            {
                if (review.ProductID == ProductID)
                {
                    result.Add(review);
                }
            }
            return result;
        }

        private IQueryable<ProductCategory> GetCategories()
        {
            ProductCategory category = new ProductCategory { Name = "NotSafe", ProductCategoryID = 1 };
            ProductCategory category2 = new ProductCategory { Name = "Safe", ProductCategoryID = 2 };

            List<ProductCategory> categories = new List<ProductCategory>()
            {
                category,
                category2
            };

            return categories.AsQueryable();
        }

        private IQueryable<ProductSubcategory> GetSubcategories()
        {
            ProductSubcategory sub = new ProductSubcategory { ProductSubcategoryID = 1, ProductCategoryID = 1 };
            ProductSubcategory sub2 = new ProductSubcategory { ProductSubcategoryID = 2, ProductCategoryID = 2 };

            List<ProductSubcategory> subs = new List<ProductSubcategory>()
            {
                sub,
                sub2
            };

            return subs.AsQueryable();
        }

        [TestMethod]
        public void get_product_by_name_from_filled_list()
        {
            // Arrange
            ProductsRepository productsRepository = new ProductsRepository(iDataContext.Object);

            // Act
            IList<Product> products = productsRepository.GetProductsByName("Blade");

            // Assert
            Assert.AreEqual(products.Count, 1);
        }
        
        [TestMethod]
        public void get_product_by_vendorName_from_filled_list()
        {
            // Arrange
            ProductsRepository productsRepository = new ProductsRepository(iDataContext.Object);

            // Act
            IList<Product> products = productsRepository.GetProductByVendorName("Apple");

            // Assert
            Assert.AreEqual(products.Count, 3);
        }

        [TestMethod]
        public void get_productNames_by_vendorName_from_filled_list()
        {
            // Arrange
            ProductsRepository productsRepository = new ProductsRepository(iDataContext.Object);

            // Act
            IList<string> productNames = productsRepository.GetProductNamesByVendorName("Apple");

            // Assert
            Assert.IsTrue(productNames.Contains("Pen"));
        }

        [TestMethod]
        public void get_vendorName_by_productName_from_filled_list()
        {
            // Arrange
            ProductsRepository productsRepository = new ProductsRepository(iDataContext.Object);

            // Act
            string vendorName = productsRepository.GetProductVendorByProductName("Pen");

            // Assert
            Assert.AreEqual(vendorName, "Apple");
        }

        [TestMethod]
        public void get_products_with_recents_reviews_from_filled_list()
        {
            // Arrange
            ProductsRepository productsRepository = new ProductsRepository(iDataContext.Object);

            // Act
            IList<Product> products = productsRepository.GetProductsWithNRecentReviews(2);

            // Assert
            Assert.AreEqual(products.Count(), 3);
        }

        [TestMethod]
        public void get_recently_reviewed_products_from_filled_list()
        {
            // Arrange
            ProductsRepository productsRepository = new ProductsRepository(iDataContext.Object);

            // Act
            IList<Product> products = productsRepository.GetNRecentlyReviewedProducts(3);

            // Assert
            Assert.AreEqual(products.Count(), 3);
        }

        [TestMethod]
        public void get_n_products_from_category_from_filled_list()
        {
            // Arrange
            ProductsRepository productsRepository = new ProductsRepository(iDataContext.Object);

            // Act
            IList<Product> products = productsRepository.GetNProductsFromCategory("Safe", 4);

            // Assert
            Assert.AreEqual(products.Count(), 4);
        }

        [TestMethod]
        public void get_total_standard_cost_by_category_from_filled_list()
        {
            // Arrange
            ProductsRepository productsRepository = new ProductsRepository(iDataContext.Object);
            ProductCategory category = new ProductCategory { Name = "NotSafe", ProductCategoryID = 1 };

            // Act
            int cost = productsRepository.GetTotalStandardCostByCategory(category);

            // Assert
            Assert.AreEqual(cost, 200);
        }
    }
}
