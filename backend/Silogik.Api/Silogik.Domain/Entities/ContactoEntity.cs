using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silogik.Domain.Entities
{
    public class ContactoEntity
    {
        public string Nombre {get; set;}

        public string Apellidos {get; set;}

        public string Email {get; set;}

        public string Comentario {get; set;}

        public string Archivo { get; set; }
    }
}
