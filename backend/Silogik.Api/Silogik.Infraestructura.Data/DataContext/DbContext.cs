using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silogik.Infraestructura.Data.DataContext
{
    internal class DbContext : IDisposable
    {
        #region Private Fields

        private bool disposedValue;
        private SqlConnection connection;
        private string DataSource = string.Empty;
        private string Catalog = string.Empty;
        private string user = string.Empty;
        private string password = string.Empty;

        #endregion Private Fields

        public DbContext()
        {
            DataSource = "DESKTOP-UUHLQ8G";
            Catalog = "SilogikApp";

            SqlConnectionStringBuilder strConnection = new SqlConnectionStringBuilder();

            strConnection.DataSource = DataSource;
            strConnection.InitialCatalog = Catalog;
            //strConnection.UserID = "";
            //strConnection.Password = "";
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

        public async Task executeNonQuery(string strProd, SqlParameter[] sqlParams)
        {
            using (SqlCommand cmd = new SqlCommand(strProd, connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParams);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<SqlDataReader> executeQuery(string strProd, SqlParameter[] sqlParams)
        {
            using (SqlCommand cmd = new SqlCommand(strProd, connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParams);
                return await cmd.ExecuteReaderAsync();
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

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~DbContext()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
