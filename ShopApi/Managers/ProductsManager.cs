using System;
using System.Data;
using System.Data.SqlClient;
using ShopApi.DatabaseLayer;
using ShopApi.DatabaseLayer.Interfaces;
using ShopApi.Managers.Interfaces;
using ShopApi.Models;

namespace ShopApi.Managers
{
    public class ProductsManager: IProductsManager
    {
        private ISQLDatabaseConfig dbConfig;
        public ProductsManager(ISQLDatabaseConfig mmtShopConfig)
        {
            dbConfig = mmtShopConfig;
        }

        public ProductsModel GetByName(string args)
        {        
            ProductsModel productsModel = new ProductsModel();

            try
            {
                var dr = dbConfig.RunSQLQuery(StoredProcedureType.ProductsByName, SqlDbType.VarChar, "@ProductName", args.ToString());

                while (dr.Read())

                    AddProductModel(productsModel, dr);

                dbConfig.CloseConnection();

                return productsModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);

                dbConfig.CloseConnection();

                return null;
            }
        }

        public ProductsModel GetAll()
        {
            ProductsModel productsModel = new ProductsModel();

            try
            {
                var dr = dbConfig.RunSQLQuery(StoredProcedureType.AllProducts, SqlDbType.VarChar);

                while (dr.Read())

                    AddProductModel(productsModel, dr);

                dbConfig.CloseConnection();

                return productsModel;
            }
            catch (Exception ex)
            {
                dbConfig.CloseConnection();
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public ProductsModel GetByCategoryId(int categoryId)
        {
            ProductsModel productsModel = new ProductsModel();

            try
            {
                var dr = dbConfig.RunSQLQuery(StoredProcedureType.ProducstByCategory, SqlDbType.Int, "@CategoryId", categoryId);

                while (dr.Read())

                    AddProductModel(productsModel, dr);

                dbConfig.CloseConnection();

                return productsModel;
            }
            catch (Exception ex)
            {
                dbConfig.CloseConnection();
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        private void AddProductModel(ProductsModel productsModel, SqlDataReader dr)
        {
            var productModel = new ProductModel()
            {
                SKU = dr.GetInt32(0),
                ProductName = dr.GetString(1),
                ProductDescription = dr.GetString(2),
                CategoryId = dr.GetInt32(3),
                CreatedDate = dr.GetDateTime(4),
                Price = dr.GetDecimal(5),
            };

            productsModel.Products.Add(productModel);
          
        }

        public ProductsModel GetById(int id)
        {
            ProductsModel productsModel = new ProductsModel();

            try
            {
                var dr = dbConfig.RunSQLQuery(StoredProcedureType.ProductById, SqlDbType.Int, "@SKU", id);

                while (dr.Read())

                    AddProductModel(productsModel, dr);

                return productsModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
    }
}
