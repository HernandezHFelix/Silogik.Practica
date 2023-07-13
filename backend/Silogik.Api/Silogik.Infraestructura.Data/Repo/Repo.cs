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
    public class Repo: IDisposable
    {
        #region Private Fields

        private DataTable dTabla;
        private bool isSuccess;
        private bool disposedValue;

        #endregion Private Fields

        #region Public Methods

        public async Task<DataTable> execuetReader(string strProd, SqlParameter[] parameters)
        {
            using (DbContext context = new DbContext())
            {
                try
                {
                    context.Open();
                    dTabla = await context.executeQuery(strProd, parameters);
                }
                catch (Exception)
                {

                }
                finally
                {
                    context.Close();
                }
            }
            return dTabla;
        }

        public async Task<bool> execuetNonReader(string strProd, SqlParameter[] parameters)
        {
            using (DbContext context = new DbContext())
            {
                try
                {
                    context.Open();
                    await context.executeNonQuery(strProd, parameters);
                    isSuccess = true;
                }
                catch (Exception)
                {
                    isSuccess = false;
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
