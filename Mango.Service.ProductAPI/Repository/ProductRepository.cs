using AutoMapper;
using Mango.Service.ProductAPI.DbContexts;
using Mango.Service.ProductAPI.Models;
using Mango.Service.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(AplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProdct(ProductDto productDto)
        {
            var product =_mapper.Map<ProductDto, Product>(productDto);
            if(product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();

            return _mapper.Map<Product,ProductDto>(product);
        }

        public async Task<bool> DeleteProductById(int id)
        {
            try 
            {
                var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            Product product = await _db.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public Task<ProductDto> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public Task<ProductDto> UpdateProductById(int id, ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
