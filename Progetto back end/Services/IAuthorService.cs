using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;

namespace Caso_Di_Studio.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetAuthorById(int id);
        Task<bool> DeleteAuthor(int id);
        Task<Author> InsertAuthor(Author author);
        Task<Author> UpdateAuthor(Author author);
    }
}