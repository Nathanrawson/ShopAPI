using Microsoft.Extensions.Configuration;
using ShopApi.DatabaseLayer.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ShopApi.DatabaseLayer
{
    public class SQLDatabaseConfig : ISQLDatabaseConfig
    {
        public SqlConnection ConnectionString;
        
        public SQLDatabaseConfig(IConfiguration configuration)
        {
            ConnectionString = new SqlConnection(configuration.GetConnectionString("MMTShopDatabase"));
        }

        public SQLDatabaseConfig(string connectionString)
        {
            ConnectionString = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnectionString()
        {
            return ConnectionString;
        }   

        public string GetStoredProcedure(StoredProcedureType procedureType)
        {
            switch (procedureType)
            {
                case StoredProcedureType.AllProducts:
                    return @"dbo.[SelectAllProducts]";        

                case StoredProcedureType.ProducstByCategory:
                    return @"dbo.[SelectProductByCategory]";

                case StoredProcedureType.ProductsByName:
                    return @"dbo.[SelectProductByName]";

                case StoredProcedureType.ProductById:
                    return @"dbo.[SelectProdctById]";

                case StoredProcedureType.CategoryById:
                    return @"dbo.[SelectCategoryById]";

                case StoredProcedureType.AllCategories:
                    return @"dbo.[SelectAllCategories]";
            }

            return null;

        }

        public SqlParameter BuildSqlParameter(string parameterName, SqlDbType dbType, object value = null)
        {
            return new SqlParameter()
            {
               ParameterName = parameterName,
               SqlDbType = dbType,
               Value = value
            };
        }

        public SqlDataReader RunSQLQuery(StoredProcedureType procedureType, SqlDbType dbType, string parameterName = null, object value = null)
        {
            var storedProcedure = GetStoredProcedure(procedureType);

            SqlCommand sqlCommand = new SqlCommand(storedProcedure, ConnectionString);

            if (value != null)
            {
                var sqlParameter = BuildSqlParameter(parameterName, dbType, value);

                sqlCommand.Parameters.Add(sqlParameter);
            }

            ConnectionString.Open();

            sqlCommand.CommandType = CommandType.StoredProcedure;

            return sqlCommand.ExecuteReaderAsync().Result;
        }

        public void CloseConnection()
        {
            ConnectionString.Close();
        }
    }
}
