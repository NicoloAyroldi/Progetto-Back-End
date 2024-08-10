using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Repository;

namespace Caso_Di_Studio.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _authorRepository.GetAuthorById(id);
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            return await _authorRepository.DeleteAuthor(id);
        }

        public async Task<Author> InsertAuthor(Author author){
            return await _authorRepository.InsertAuthor(author);
        }

        public async Task<Author> UpdateAuthor(Author author){
            return await _authorRepository.UpdateAuthor(author);
        }
    }
}