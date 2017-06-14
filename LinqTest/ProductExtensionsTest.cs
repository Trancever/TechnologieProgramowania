using Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    [TestClass]
    public class ProductExtensionsTest
    {
        private List<Product> products;

        [TestInitialize]
        public void initialize()
        {
            products = new List<Product>(GetProducts());
        }

        private List<Product> GetProducts()
        {
            Vendor vendor = new Vendor { Name = "Apple", BusinessEntityID = 1 };
            Vendor vendor2 = new Vendor { Name = "Microsoft", BusinessEntityID = 2 };

            Product product = new Product { Name = "Blade", ProductID = 1, ProductSubcategoryID = 1};
            Product product2 = new Product { Name = "Hat", ProductID = 2, ProductSubcategoryID = 2};
            Product product3 = new Product { Name = "Knife", ProductID = 3, ProductSubcategoryID = 1};
            Product product4 = new Product { Name = "Phone", ProductID = 4, ProductSubcategoryID = 2};
            Product product5 = new Product { Name = "Cup", ProductID = 5, ProductSubcategoryID = null };
            Product product6 = new Product { Name = "Notebook", ProductID = 6, ProductSubcategoryID = null };
            Product product7 = new Product { Name = "Headphones", ProductID = 7, ProductSubcategoryID = 2};
            Product product8 = new Product { Name = "Pen", ProductID = 8, ProductSubcategoryID = null };
            Product product9 = new Product { Name = "Keyboard", ProductID = 9, ProductSubcategoryID = 2 };

            ProductVendor pVendor = new ProductVendor { Vendor = vendor, Product = product };
            ProductVendor pVendor2 = new ProductVendor { Vendor = vendor2, Product = product2 };

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

            return products;
        }

        [TestMethod]
        public void get_products_with_no_category_from_filled_list()
        {
            // Arrange

            // Act
            IList<Product> result = products.GetProductsWithNoCategoryAssigned();

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void get_products_by_size_and_page_from_filled_list()
        {
            // Act
            IList<Product> result = products.GetProductsBySizeAndPage(2, 2);

            // Assert
            Assert.AreEqual(result[0].Name, "Cup");
        }

        [TestMethod]
        public void get_product_and_vendor_name_from_filled_list()
        {
            string result = products.GetProductsNameAndTheirVendorsNamesAsString();

            Assert.AreEqual("Blade,Apple\nHat,Microsoft\n", result);

        }

    }
}
