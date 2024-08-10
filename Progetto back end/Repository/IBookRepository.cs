using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;

namespace Caso_Di_Studio.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetBookById(int id);
        Task<bool> DeleteBook(int id);
        Task<Book> InsertBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<IEnumerable<Book>> GetBooksByCategory(int categoryId);
        Task<IEnumerable<Book>> GetBooksByAuthor(int authorId);
    }
}