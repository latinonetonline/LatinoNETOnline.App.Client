using System;

using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Events;

namespace LatinoNETOnline.App.Client.Core.Services
{
    public interface IEventClientService
    {
        Task<Response> CreateEventAsync(CreateEventRequest @event);
        Task<Response> UpdateEventAsync(Event @event);
        Task<Response> UpdateNextEventAsync(Event @event);
        Task<Response> DeleteEventAsync(Event @event);
        Task<Response<Event>> GetEventAsync(int year, int month, Guid id);
        Task<ResponseEnumerable<Event>> GetEventsAsync(int year, int month);
        Task<Response<Event>> GetNextEventAsync();
        Task<Response> ConvertDraftToPublishAsync(ConvertDraftToPublishRequest @event);
    }
}
