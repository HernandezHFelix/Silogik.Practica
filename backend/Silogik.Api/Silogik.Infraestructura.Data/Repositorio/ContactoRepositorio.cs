using Silogik.Business.Interfaces.Repositorio;
using Silogik.Domain.Entities;
using Silogik.Infraestructura.Data.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silogik.Core.Repositorio
{
    public class ContactoRepositorio : IContactoRepositorio
    {
        public async Task<ContactoEntity> GuardaContacto(ContactoEntity entity)
        {
            using (Repo repo = new Repo()) {
                string prod = "sp_guarda_contacto";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@pNombre", entity.Nombre),
                    new SqlParameter("@pApellidos", entity.Apellidos),
                    new SqlParameter("@pEmail", entity.Email),
                    new SqlParameter("@pComentario", entity.Comentario),
                    new SqlParameter("@pArchivo", entity.Archivo)
                };
                await repo.execuetNonReader(prod, param);
            }
            return entity;
        }

        public async Task<List<ContactoEntity>> ObtieneContactos()
        {
            List<ContactoEntity> contactos = new List<ContactoEntity>();
            using (Repo rep = new Repo())
            {
                string prod = "sp_Obtiene_Contactos";
                SqlParameter[] param = new SqlParameter[] { };
                DataTable infoTabla = await rep.execuetReader(prod, param);
                foreach(DataRow fila in infoTabla.Rows) 
                {
                    contactos.Add(new ContactoEntity()
                    {
                        Nombre = fila["nombre"].ToString(),
                        Apellidos = fila["apellidos"].ToString(),
                        Email = fila["email"].ToString(),
                        Comentario = fila["comentario"].ToString(),
                        Archivo = fila["archivo"].ToString()
                    }); 
                }
            }
            return contactos;
        }
    }
}
