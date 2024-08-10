using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Repository;


namespace Caso_Di_Studio.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _bookRepository.DeleteBook(id);
        }

        public async Task<Book> InsertBook(Book book){
            return await _bookRepository.InsertBook(book);
        }

        public async Task<Book> UpdateBook(Book book){
            return await _bookRepository.UpdateBook(book);
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            return await _bookRepository.GetBooksByCategory(categoryId);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId)
        {
            return await _bookRepository.GetBooksByAuthor(authorId);
        }

        
    }
}
