using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silogik.Business.Interfaces.Repositorio;
using Silogik.Domain.Entities;

namespace Silogik.Api.Controllers
{
    [ApiController]
    [Route("api/contacto")]
    public class ContactoController : Controller
    {
        private readonly IContactoRepositorio contactoRepositorio;

        public ContactoController(IContactoRepositorio icontactoRepositorio)
        {
            contactoRepositorio = icontactoRepositorio;
        }

        [HttpGet]
        [Route("getContacto")] 
        public async Task<ActionResult<List<ContactoEntity>>> ObtieneContactos()
        {
            return await contactoRepositorio.ObtieneContactos();
        }
    }
}
