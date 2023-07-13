using Silogik.Domain.Interfaces.Repositorio;
using Silogik.Domain.Entities;
using Silogik.Infraestructura.Data.Repo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silogik.Infraestructura.Data.Repositorio
{
    public class TraductorRepositorio : ITraductorRepositorio
    {
        public async Task<List<TraductorEntity>> ObtieneTraduccion(string tipoTraduccion)
        {
            List<TraductorEntity> listaTraductor = new List<TraductorEntity>();
            using (RepoUnitOrWork repo = new RepoUnitOrWork())
            {
                string strProcedimiento = "sp_obtiene_traduccion_palabras";
                SqlParameter[] parametros = new SqlParameter[] {
                    new SqlParameter("@pTipoTraduccion", tipoTraduccion)
                };
                DataTable infoTabla = await repo.ExecuteProcedureQueryAsync(strProcedimiento, parametros);
                foreach (DataRow fila in infoTabla.Rows)
                {
                    listaTraductor.Add(new TraductorEntity()
                    {
                        tipo_etiqueta = fila["tipo_etiqueta"].ToString(),
                        letra_traduccion = fila["letra_traduccion"].ToString(),
                    });
                }
            }
            return listaTraductor;
        }
    }
}
