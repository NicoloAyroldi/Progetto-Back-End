using Caso_Di_Studio.Data;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Repository;
using Caso_Di_Studio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Caso_Di_Studio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var books = await _bookService.GetAll();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore nel recupero dei libri.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookService.GetBookById(id);
                if (book == null)
                {
                    return NotFound("Libro non trovato.");
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore nel recupero del libro.");
            }
        }

       [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _bookService.DeleteBook(id);
                if (!result)
                {
                    return NotFound(new { message = "Libro non trovato." });
                }

                // Invia un messaggio di successo come JSON
                return Ok(new { message = "Libro eliminato con successo." });
            }
            catch (Exception ex)
            {
                // Restituisce un messaggio di errore come JSON
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Errore durante la cancellazione del libro.", error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> InsertBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("I dati del libro non sono validi.");
            }

            try
            {
                await _bookService.InsertBook(book);
                return CreatedAtAction(nameof(GetAll), new { id = book.Id }, book);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante l'inserimento del libro.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore generico durante l'inserimento del libro.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("I dati del libro non sono validi.");
            }

            try
            {
                var updatedBook = await _bookService.UpdateBook(book);
                if (updatedBook == null)
                {
                    return NotFound("Libro non trovato.");
                }
                return Ok(updatedBook);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante l'aggiornamento del libro.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore generico durante l'aggiornamento del libro.");
            }
        }

        // BookController.cs
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetBooksByCategory(int categoryId)
        {
            try
            {
                var books = await _bookService.GetBooksByCategory(categoryId);
                if (books == null || books.Count() == 0)
                {
                    return NotFound("Nessun libro trovato per questa categoria.");
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante il recupero dei libri.");
            }
        }

        [HttpGet("author/{authorId}")]
        public async Task<IActionResult> GetBooksByAuthor(int authorId)
        {
            try
            {
                var books = await _bookService.GetBooksByAuthor(authorId);
                if (books == null || books.Count() == 0)
                {
                    return NotFound("Nessun libro trovato per questa categoria.");
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante il recupero dei libri.");
            }
        }
    }
}