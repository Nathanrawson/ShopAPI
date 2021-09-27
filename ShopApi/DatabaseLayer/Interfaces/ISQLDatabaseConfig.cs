using System.Data;
using System.Data.SqlClient;

namespace ShopApi.DatabaseLayer.Interfaces
{
    public interface ISQLDatabaseConfig
    {
        public SqlConnection GetConnectionString();

        public SqlParameter BuildSqlParameter(string parameterName, SqlDbType dbType, object value);

        public string GetStoredProcedure(StoredProcedureType procedureType);

        void CloseConnection();

        SqlDataReader RunSQLQuery(StoredProcedureType procedureType, SqlDbType dbType, string parameterName = null, object value = null);
    }
}
