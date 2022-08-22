using Mango.Web.Models;
using Newtonsoft.Json.Linq;

namespace Mango.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int productId, string token);
        Task<T> GetProductByNameAsync<T>(string productName, string token);
        Task<T>CreateProductAsync<T>(ProductDto productDto, string token);
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        Task<T> DeleteProductByIdAsync<T>(int productId, string token);

    }
}
