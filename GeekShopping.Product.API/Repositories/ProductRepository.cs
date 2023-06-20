using AutoMapper;
using GeekShopping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Models;
using GeekShopping.Product.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindByIdAsync(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> CreateAsync(ProductVO product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(productEntity);
        }

        public async Task<ProductVO> UpdateAsync(ProductVO product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            _context.Products.Update(productEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(productEntity);
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            try
            {
                var productFounded = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (productFounded is null) return false;

                _context.Remove(productFounded);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
