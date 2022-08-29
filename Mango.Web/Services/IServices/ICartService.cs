using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface ICartService
    {
        Task<T> GetCartByUserAsync<T>(string userid, string token = null);
        Task<T> AddtoCartAsync<T>(CartDto cartDto, string token = null);
        Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null);
        Task<T> RemoveFromCartAsync<T>(int cartid, string token = null);
        Task<T> ApplyCoupon<T>(CartDto cartDto, string token = null);
        Task<T> RemoveCoupon<T>(string userid, string token = null);
        Task<T> Checkout<T>(CartHeaderDto cartHeaderDto, string token = null);
    }
}
