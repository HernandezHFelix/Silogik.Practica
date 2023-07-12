using Silogik.Business.Interfaces.Repositorio;
using Silogik.Domain.Entities;
using Silogik.Infraestructura.Data.Repo;
using System;
using System.Collections.Generic;
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
            return entity;
        }

        public async Task<List<ContactoEntity>> ObtieneContactos()
        {
            List<ContactoEntity> contacts = new List<ContactoEntity>();
            using (Repo rep = new Repo())
            {
                string prod = "sp_Obtiene_Contactos";
                SqlParameter[] param = new SqlParameter[] { };
                SqlDataReader reader = await rep.execuetReader(prod, param);

                while (reader.Read()) {
                    contacts.Add(new ContactoEntity()
                    {
                        Nombre = reader["nombre"].ToString(),
                        Apellidos = reader["apellidos"].ToString(),
                        Email = reader["email"].ToString(),
                        Comentario = reader["comentario"].ToString(),
                        Archivo = reader["archivo"].ToString()
                    }); 
                }
            }
            return contacts;
        }
    }
}
