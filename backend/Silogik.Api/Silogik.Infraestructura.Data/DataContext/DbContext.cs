using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Silogik.Infraestructura.Data.DataContext
{
    internal class DbContext : IDisposable
    {
        #region Private Fields

        private bool disposedValue;
        private SqlConnection connection;
        private DataTable queryTabla = new DataTable();
        private SqlDataReader dataReader;
        private string dataSource = string.Empty;
        private string catalog = string.Empty;
        private string user = string.Empty;
        private string password = string.Empty;

        #endregion Private Fields

        public DbContext()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfiguration config = configurationBuilder.AddJsonFile("appsettings.json").Build();

            dataSource = config["connection:datasource"];
            catalog = config["connection:catalog"];

            SqlConnectionStringBuilder strConnection = new SqlConnectionStringBuilder();

            strConnection.DataSource = dataSource;
            strConnection.InitialCatalog = catalog;
            strConnection.IntegratedSecurity = true;

            connection = new SqlConnection(strConnection.ConnectionString);
        }

        public void Open()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void Close()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public async Task ExecuteProcedureNonQueryAsync(string strProd, SqlParameter[] sqlParams)
        {
            using (SqlCommand cmd = new SqlCommand(strProd, connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParams);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<DataTable> ExecuteProcedureQueryAsync(string strProd, SqlParameter[] sqlParams)
        { 
            using (SqlCommand cmd = new SqlCommand(strProd, connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParams);
                dataReader = await cmd.ExecuteReaderAsync();
                queryTabla.Load(dataReader);
                return queryTabla;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
