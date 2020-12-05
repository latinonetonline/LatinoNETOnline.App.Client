using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Eventbrite.Orders;
using LatinoNETOnline.App.Client.Core.Services;

namespace LatinoNETOnline.App.Client.Services
{
    public class EventbriteClientService : IEventbriteClientService
    {
        private readonly HttpClient _httpClient;
        public EventbriteClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Response<OrderPage>> GetOrderPageAsync(string eventId, int page)
        {
            return await _httpClient.GetFromJsonAsync<Response<OrderPage>>($"api/Eventbrite/GetOrderPage/{eventId}/{page}");
        }
    }
}
