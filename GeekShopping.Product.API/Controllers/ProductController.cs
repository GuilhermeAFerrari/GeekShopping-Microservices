using GeekShopping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Models.Context;
using GeekShopping.Product.API.Repositories;
using GeekShopping.Product.API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(SqlServerContext context, IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create([FromBody]ProductVO productVO)
        {
            if (productVO is null) return BadRequest();
            var product = await _repository.CreateAsync(productVO);
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Update([FromBody]ProductVO productVO)
        {
            if (productVO is null) return BadRequest();
            var product = await _repository.UpdateAsync(productVO);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.ADMIN)]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteByIdAsync(id);
            return status ? Ok(status) : BadRequest();
        }
    }
}
