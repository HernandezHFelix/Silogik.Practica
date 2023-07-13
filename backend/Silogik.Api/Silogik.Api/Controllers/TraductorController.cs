using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silogik.Api.Models;
using Silogik.Domain.Interfaces.Repositorio;
using Silogik.Core.Repositorio;
using Silogik.Domain.Entities;

namespace Silogik.Api.Controllers
{
    [ApiController]
    [Route("api/traductor")]
    public class TraductorController : Controller
    {
        private readonly ITraductorRepositorio traductorRepositorio;

        public TraductorController(ITraductorRepositorio itraductorRepositorio)
        {
            traductorRepositorio = itraductorRepositorio;
        }

        [HttpPost]
        [Route("getTraduccion")]
        public async Task<ActionResult<List<TraductorEntity>>> ObtienTraduccion(TraductorModel entity)
        {
            return await traductorRepositorio.ObtieneTraduccion(entity.TipoTraduccion);
        }
    }
}
