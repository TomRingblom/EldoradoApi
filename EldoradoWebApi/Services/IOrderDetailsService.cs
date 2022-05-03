using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.OrderDetails;

namespace EldoradoWebApi.Services
{
    public interface IOrderDetailsService
    {
        Task CreateDetails(OrderDetailsCreate model);
        Task<IEnumerable<OrderDetailsObject>> GetDetails(int id);
        Task<OrderDetailsObject> UpdateDetails(int id, OrderDetailsUpdate model);
        
    }
}
