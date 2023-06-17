using GeekShopping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Models.Context;
using GeekShopping.Product.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SqlServerContext _context;
        private readonly IProductRepository _repository;

        public ProductController(SqlServerContext context, IProductRepository repository)
        {
            _context = context;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO productVO)
        {
            if (productVO is null) return BadRequest();
            var product = await _repository.CreateAsync(productVO);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO productVO)
        {
            if (productVO is null) return BadRequest();
            var product = await _repository.UpdateAsync(productVO);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteAsync(id);
            return status ? Ok(status) : BadRequest();
        }
    }
}
