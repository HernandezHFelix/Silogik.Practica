using Microsoft.VisualBasic;
using Silogik.Infraestructura.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silogik.Infraestructura.Data.Repo
{
    public class RepoUnitOrWork: IDisposable
    {
        #region Private Fields

        private DataTable queryTabla = new DataTable();
        private bool isSuccess = false;
        private bool disposedValue;

        #endregion Private Fields

        #region Public Methods

        public async Task<DataTable> ExecuteProcedureQueryAsync(string strProd, SqlParameter[] parameters)
        {
            using (DbContext context = new DbContext())
            {
                try
                {
                    context.Open();
                    queryTabla = await context.ExecuteProcedureQueryAsync(strProd, parameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    context.Close();
                }
            }
            return queryTabla;
        }

        public async Task<bool> ExecuteProcedureNonQueryAsync(string strProd, SqlParameter[] parameters)
        {
            using (DbContext context = new DbContext())
            {
                try
                {
                    context.Open();
                    await context.ExecuteProcedureNonQueryAsync(strProd, parameters);
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    context.Close();
                }
            }
            return isSuccess;
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

        #endregion Public Methods
    }
}
