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
    public class MyProductTest
    {
        private IDataContext _iDataContext;

        [TestInitialize]
        public void initialize()
        {
            LinqToSqlDataContext sqlContext = new LinqToSqlDataContext(new DataClasses1DataContext());
            _iDataContext = new MyProductsDataContext(sqlContext.Repository<Product>().ToList(), sqlContext.Repository<ProductReview>().ToList());
        }

        [TestMethod]
        public void get_myProduct_by_name_from_filled_list()
        {
            // Arrange
            MyProductRepository myProductsRepository = new MyProductRepository(_iDataContext);

            // Act
            IList<MyProduct> products = myProductsRepository.GetProductsByName("Blade");

            // Assert
            Assert.AreEqual(products.Count, 0);
        }

        [TestMethod]
        public void get_myProducts_with_n_recent_reviews()
        {
            // Arrange
            MyProductRepository myProductsRepository = new MyProductRepository(_iDataContext);

            // Act
            IList<MyProduct> products = myProductsRepository.GetMyProductsWithNRecentReviews(1);

            // Assert
            Assert.AreEqual(products.Count, 2);
        }

        [TestMethod]
        public void get_last_n_reviewed_MyProducts()
        {
            // Arrange
            MyProductRepository myProductsRepository = new MyProductRepository(_iDataContext);

            // Act
            IList<MyProduct> products = myProductsRepository.GetNRecentlyReviewedProducts(2);

            // Assert
            Assert.AreEqual(products.Count, 2);
            Assert.AreEqual(products[0].ProductID, 798);
            Assert.AreEqual(products[1].ProductID, 937);
        }




    }
}
