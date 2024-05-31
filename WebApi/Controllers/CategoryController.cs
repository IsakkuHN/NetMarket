using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {

        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryController(IGenericRepository<Category> categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategoryAll() {
            return Ok(await _categoryRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryByIdAsync(int id) {
            return await _categoryRepository.GetByIdAsync(id);
        }
    }
}
