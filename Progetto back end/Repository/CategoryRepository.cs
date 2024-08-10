using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Data;
using Caso_Di_Studio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caso_Di_Studio.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            // Usa FindAsync per cercare un'entità con la chiave primaria
            return await _context.Category.FindAsync(id);
        }


        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category> InsertCategory(Category category){
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(Category category){
            var categoryToUpdate = await _context.Category.FindAsync(category.Id);
            if (categoryToUpdate == null)
            {
                return null;
            }
            
            categoryToUpdate.Nome = category.Nome;
            
            await _context.SaveChangesAsync();
            return categoryToUpdate;
        }
    }
}