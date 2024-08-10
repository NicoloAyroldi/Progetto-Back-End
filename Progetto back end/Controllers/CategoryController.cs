using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caso_Di_Studio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAll();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory([FromBody] Category category){
            await _categoryService.InsertCategory(category);
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var UpdateCategory = await _categoryService.UpdateCategory(category);
            if(UpdateCategory == null){
                return NotFound();
            }
            return Ok(UpdateCategory);
            
        }

    }
}