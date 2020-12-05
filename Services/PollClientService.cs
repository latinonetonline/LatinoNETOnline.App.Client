using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Polls;
using LatinoNETOnline.App.Client.Core.Services;

namespace LatinoNETOnline.App.Client.Services
{
    public class PollClientService : IPollClientService
    {
        private readonly HttpClient _httpClient;

        public PollClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> CreatePollAsync(NewPoll poll)
        {
            CreatePollRequest request = new CreatePollRequest
            {
                Question = poll.Question,
                Answers = new[] { poll.Answer1, poll.Answer2, poll.Answer3, poll.Answer4 }
            };
            var httpResponse = await _httpClient.PostAsJsonAsync($"api/Polls", request);
            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response> DeleteAllAsync()
        {
            HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/polls");
            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response> DeletePollAsync(Guid pollId)
        {
            HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/polls/{pollId}");
            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<ResponseEnumerable<PollOptions>> GetPollsAsync()
        {
            return await _httpClient.GetFromJsonAsync<ResponseEnumerable<PollOptions>>($"api/polls");
        }

        public async Task<Response> ShowPollAsync(Guid pollId)
        {
            PollShow pollShow = new PollShow
            {
                PollId = pollId
            };

            var httpResponse = await _httpClient.PostAsJsonAsync($"api/polls/show", pollShow);
            return await httpResponse.Content.ReadFromJsonAsync<Response>();
        }
    }
}
