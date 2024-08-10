using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Caso_Di_Studio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;
        public AuthorController(IAuthorService authorService)
        {
            _AuthorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var authors = await _AuthorService.GetAll();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore nel recupero degli autori.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _AuthorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _AuthorService.DeleteAuthor(id);
                if (!result)
                {
                    return NotFound("Autore non trovato.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante la cancellazione dell'autore.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertAuthor([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest("I dati dell'autore non sono validi.");
            }

            try
            {
                await _AuthorService.InsertAuthor(author);
                return CreatedAtAction(nameof(GetAll), new { id = author.Id }, author);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante l'inserimento dell'autore.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore generico durante l'inserimento dell'autore.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest("I dati dell'autore non sono validi.");
            }

            try
            {
                var updatedAuthor = await _AuthorService.UpdateAuthor(author);
                if (updatedAuthor == null)
                {
                    return NotFound("Autore non trovato.");
                }
                return Ok(updatedAuthor);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante l'aggiornamento dell'autore.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore generico durante l'aggiornamento dell'autore.");
            }
        }
    }
}
