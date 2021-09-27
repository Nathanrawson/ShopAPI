using NUnit.Framework;
using ShopApi.DatabaseLayer;
using ShopApi.DatabaseLayer.Interfaces;
using ShopApi.Managers;
using ShopApi.Managers.Interfaces;
using System.Linq;

namespace ShopUnitTests
{
    public class TestDBSetup
    {
        public ISQLDatabaseConfig dbConfig;
        public string connectionString = "data source=PCBRO\\SQLEXPRESS;initial catalog=MMTShop;trusted_connection=true;";
        
        public TestDBSetup()
        {
            dbConfig = new SQLDatabaseConfig(connectionString);          
        }
    
    }
    public class ProductTests: TestDBSetup
    {
        IProductsManager _productsManager;
       

        [SetUp]
        public void Setup()
        {
            _productsManager = new ProductsManager(dbConfig);
        }

        [Test]
        public void TestGetAllProducts()
        {
            var products = _productsManager.GetAll();

            Assert.True(products != null &&
                products.Products != null 
                &&products.Products.Count > 0);
        }

        [Test]
        public void TestGetByCategoryId()
        {
            var products = _productsManager.GetByCategoryId(2);

            Assert.True(products != null &&
                products.Products != null
                && products.Products.Count > 0 
                && !products.Products.Any(x => x.CategoryId != 2));
        }
    }

    public class CategoryTests: TestDBSetup
    {
        ICategoryManager _CategoryManager;
        
        [SetUp]
        public void Setup()
        {
            dbConfig = new SQLDatabaseConfig(connectionString);
            _CategoryManager = new CategoryManager(dbConfig);
        }

        [Test]
        public void TestGetAllProducts()
        {
            var categories = _CategoryManager.GetAll();

            Assert.True(categories != null &&
                categories != null
                && categories.Count > 0);
        }

        [Test]
        public void TestGetByCategoryId()
        {
            var categories = _CategoryManager.GetById(2);

            Assert.True(categories != null &&
                categories != null
                && categories.Count > 0
                && !categories.Any(x => x.CategoryId != 2));
        }
    }
}