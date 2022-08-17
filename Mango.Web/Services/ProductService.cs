using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory) :base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
           return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products/",
                AccesToken = ""
            });
        }

        public async Task<T> DeleteProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/products/" + productId,
                AccesToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products/",
                AccesToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products/" + productId,
                AccesToken = ""
            });
        }

        public Task<T> GetProductByNameAsync<T>(string productName)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products/",
                AccesToken = ""
            });
        }
    }
}
