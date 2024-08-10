using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Repository;

namespace Caso_Di_Studio.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _categoryRepository.DeleteCategory(id);
        }

        public async Task<Category> InsertCategory(Category category){
            return await _categoryRepository.InsertCategory(category);
        }

        public async Task<Category> UpdateCategory(Category category){
            return await _categoryRepository.UpdateCategory(category);
        }
    }
}