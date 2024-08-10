using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Data;
using Caso_Di_Studio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caso_Di_Studio.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Book> InsertBook(Book book){
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(Book book){
            var bookToUpdate = await _context.Books.FindAsync(book.Id);
            if (bookToUpdate == null)
            {
                return null;
            }
            
            bookToUpdate.Titolo = book.Titolo;
            bookToUpdate.Anno = book.Anno;
            bookToUpdate.Descrizione = book.Descrizione;
            bookToUpdate.CategoryId = book.CategoryId;
            bookToUpdate.AuthorId = book.AuthorId;
            bookToUpdate.PublishingHId = book.PublishingHId;

            
            await _context.SaveChangesAsync();
            return bookToUpdate;
        }
        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            return await _context.Books
                         .Where(b => b.CategoryId == categoryId)
                         .ToListAsync();
        }
         public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId)
        {
            return await _context.Books
                         .Where(b => b.AuthorId == authorId)
                         .ToListAsync();
        }
    }
}