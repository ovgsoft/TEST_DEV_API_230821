using ApiCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestPrueba.Models;

namespace ApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasFisicasController : ControllerBase
    {
        private readonly dbproductosContext _db;

        public PersonasFisicasController(dbproductosContext db)
        {
            _db = db;

        }
        [HttpGet]
        public async Task<IActionResult> GetPersonaFisica()
        {
            var lista = await _db.PersonaFisica.OrderBy(c => c.Nombre).ToListAsync();
            return Ok(lista);
        }
        [HttpPost]
        public async Task<IActionResult> CrearPersonaFisica([FromBody] PersonasFisicas personasFisicas )
        {
            if (personasFisicas == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            await _db.AddAsync(personasFisicas);
            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}
