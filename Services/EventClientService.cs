using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Events;
using LatinoNETOnline.App.Client.Core.Services;

namespace LatinoNETOnline.App.Client.Services
{
    public class EventClientService : IEventClientService
    {
        private readonly HttpClient _httpClient;
        public EventClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> CreateEventAsync(CreateEventRequest @event)
        {
            @event.Date = DateTime.SpecifyKind(@event.Date, DateTimeKind.Utc);
            HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync("api/Events", @event);

            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response> DeleteEventAsync(Event @event)
        {
            HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/events/{@event.Date.Year}/{@event.Date.Month}/{@event.Guid}");
            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response<Event>> GetEventAsync(int year, int month, Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Response<Event>>($"api/Events/{year}/{month}/{id}");
        }

        public async Task<ResponseEnumerable<Event>> GetEventsAsync(int year, int month)
        {
            return await _httpClient.GetFromJsonAsync<ResponseEnumerable<Event>>($"api/Events/{year}/{month}");
        }

        public async Task<Response<Event>> GetNextEventAsync()
        {
            return await _httpClient.GetFromJsonAsync<Response<Event>>($"api/Events/GetNextEvent");
        }

        public async Task<Response> UpdateEventAsync(Event @event)
        {
            @event.Date = DateTime.SpecifyKind(@event.Date, DateTimeKind.Utc);
            var httpResponse = await _httpClient.PutAsJsonAsync<Event>("api/Events", @event);
            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response> UpdateNextEventAsync(Event @event)
        {
            HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync("api/events/updatenextevent", @event);

            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response> ConvertDraftToPublishAsync(ConvertDraftToPublishRequest @event)
        {
            HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync("api/events/publish", @event);

            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }
    }
}
