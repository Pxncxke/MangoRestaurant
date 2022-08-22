using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Newtonsoft.Json.Linq;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory) :base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
           return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products/",
                AccesToken = token
           });
        }

        public async Task<T> DeleteProductByIdAsync<T>(int productId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/products/" + productId,
                AccesToken = token
            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products/",
                AccesToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products/" + productId,
                AccesToken = token
            });
        }

        public Task<T> GetProductByNameAsync<T>(string productName, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products/",
                AccesToken = token
            });
        }
    }
}
