using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {
    public class BrandController : BaseApiController {

        public readonly IGenericRepository<Brand> _brandRepository;

        public BrandController(IGenericRepository<Brand> brandRepository) {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetAllBrandsAsync() {
            return Ok(await _brandRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrandByIdAsync(int id) {
            return await _brandRepository.GetByIdAsync(id);
        }
    }
}
