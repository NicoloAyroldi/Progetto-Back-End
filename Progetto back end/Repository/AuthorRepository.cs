using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Data;
using Caso_Di_Studio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caso_Di_Studio.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Author.ToListAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            // Usa FindAsync per cercare un'entità con la chiave primaria
            return await _context.Author.FindAsync(id);
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Author> InsertAuthor(Author author){
            _context.Author.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAuthor(Author author){
            var authorToUpdate = await _context.Author.FindAsync(author.Id);
            if (authorToUpdate == null)
            {
                return null;
            }
            
            authorToUpdate.Nome = author.Nome;
            authorToUpdate.Cognome = author.Cognome;
            authorToUpdate.Citta = author.Citta;
            authorToUpdate.Indirizzo = author.Indirizzo;
            
            await _context.SaveChangesAsync();
            return authorToUpdate;
        }
    }
}