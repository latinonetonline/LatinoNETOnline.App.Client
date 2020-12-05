using System;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Polls;

namespace LatinoNETOnline.App.Client.Core.Services
{
    public interface IPollClientService
    {
        Task<ResponseEnumerable<PollOptions>> GetPollsAsync();
        Task<Response> CreatePollAsync(NewPoll poll);
        Task<Response> DeletePollAsync(Guid pollId);
        Task<Response> ShowPollAsync(Guid pollId);
        Task<Response> DeleteAllAsync();
    }
}
