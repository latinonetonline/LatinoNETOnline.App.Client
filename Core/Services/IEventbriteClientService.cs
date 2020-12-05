using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Eventbrite.Orders;

namespace LatinoNETOnline.App.Client.Core.Services
{
    public interface IEventbriteClientService
    {
        Task<Response<OrderPage>> GetOrderPageAsync(string eventId, int page);
    }
}
