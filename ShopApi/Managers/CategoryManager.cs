using ShopApi.DatabaseLayer;
using ShopApi.DatabaseLayer.Interfaces;
using ShopApi.Managers.Interfaces;
using ShopApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopApi.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ISQLDatabaseConfig dbConfig;

        public CategoryManager(ISQLDatabaseConfig config)
        {
            dbConfig = config;
        }

        public List<CategoryModel> GetById(int id)
        {
            List<CategoryModel> categoryList = new List<CategoryModel>();

            try
            {
                var dr = dbConfig.RunSQLQuery(StoredProcedureType.CategoryById, SqlDbType.Int, "@CategoryId", id);

                while (dr.Read())

                    AddCategoryModel(categoryList, dr);

                dbConfig.CloseConnection();

                return categoryList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public List<CategoryModel> GetAll()
        {
            List<CategoryModel> categoryList = new List<CategoryModel>();

            try
            {
                var dr = dbConfig.RunSQLQuery(StoredProcedureType.AllCategories, SqlDbType.VarChar);

                while (dr.Read())

                    AddCategoryModel(categoryList, dr);

                dbConfig.CloseConnection();

                return categoryList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public List<CategoryModel> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        private void AddCategoryModel(List<CategoryModel> categoryList, SqlDataReader dr)
        {
            var categoryModel = new CategoryModel()
            {
                CategoryId = dr.GetInt32(0),
                CategoryName = dr.GetString(1),
            };

            categoryList.Add(categoryModel);
        }
    }
}
