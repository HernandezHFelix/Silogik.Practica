using Silogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silogik.Domain.Interfaces.Repositorio
{
    public interface ITraductorRepositorio
    {
        Task<List<TraductorEntity>> ObtieneTraduccion(string tipoTraduccion);
    }
}
