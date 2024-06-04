using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.ErrorHandling;

namespace WebApi.Controllers {
    public class ProductController : BaseApiController {

        private readonly IGenericRepository<Product> _productRepository;

        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery]ProductSpecificationParams productParams) {

            var spec = new ProductWithCategoryAndBrandSpecification(productParams);

            var products = await _productRepository.GetAllWithSpec(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id) {

            // spec = debe incluir la logica de la condicion de la consulta y tambien las relaciones entre 
            //las entidades, la relacion entre Producto y Marca, Categoria 
            var spec = new ProductWithCategoryAndBrandSpecification(id);
            var product = await _productRepository.GetByIdWithSpec(spec);

            if(product == null) {
                return NotFound(new CodeErrorResponse(404, "Product does not exists."));
            }

            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
