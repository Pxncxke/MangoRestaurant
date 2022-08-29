using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> AddtoCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/AddCart/",
                AccesToken = token
            });
        }

        public async Task<T> ApplyCoupon<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/ApplyCoupon/",
                AccesToken = token
            });
        }

        public async Task<T> Checkout<T>(CartHeaderDto cartHeaderDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.POST,
                Data = cartHeaderDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/Checkout/",
                AccesToken = token
            });
        }

        public async Task<T> GetCartByUserAsync<T>(string userid, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ShoppingCartAPIBase + "/api/cart/GetCart/" + userid,
                AccesToken = token
            });
        }

        public async Task<T> RemoveCoupon<T>(string userid, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.POST,
                Data = userid,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCoupon/",
                AccesToken = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartid, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.POST,
                Data = cartid,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCart",
                AccesToken = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Apitype = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/UpdateCart",
                AccesToken = token
            });
        }
    }
}
