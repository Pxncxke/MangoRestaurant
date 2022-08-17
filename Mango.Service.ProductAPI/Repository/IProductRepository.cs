using Mango.Service.ProductAPI.Models.Dto;

namespace Mango.Service.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> GetProductByName(string name);
        Task<ProductDto> CreateUpdateProdct(ProductDto product);
        Task<ProductDto> UpdateProductById(int id, ProductDto product);
        Task<bool> DeleteProductById(int id);

    }
}
