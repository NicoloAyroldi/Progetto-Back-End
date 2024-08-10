using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;

namespace Caso_Di_Studio.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetCategoryById(int id);
        Task<bool> DeleteCategory(int id);
        Task<Category> InsertCategory(Category category);
        Task<Category> UpdateCategory(Category category);
    }
}