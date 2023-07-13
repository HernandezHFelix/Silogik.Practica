using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silogik.Domain.Entities;
using Silogik.Domain.Interfaces.Repositorio;

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

        [HttpPost]
        [Route("addContacto")]
        public async Task<ActionResult<ContactoEntity>> AgregaContacto(ContactoEntity entity)
        {
            return await contactoRepositorio.GuardaContacto(entity);
        }
    }
}
