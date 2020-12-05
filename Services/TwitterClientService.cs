using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Twitter;
using LatinoNETOnline.App.Client.Core.Services;

namespace LatinoNETOnline.App.Client.Services
{
    public class TwitterClientService : ITwitterClientService
    {
        private readonly HttpClient _httpClient;
        public TwitterClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<TweetResult>> CreateTweetAsync(CreateTweetRequest tweet)
        {
            tweet.Date = DateTime.SpecifyKind(tweet.Date, DateTimeKind.Utc);
            HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync("api/Twitter", tweet);

            Response<TweetResult> res = await httpResponse.Content.ReadFromJsonAsync<Response<TweetResult>>();
            return res;
        }

        public async Task<Response<MentionsAndHashtags>> GetLastMentionsAndHashtagsAsync()
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync("api/Twitter/GetLastMentionsAndHashtags");

            Response<MentionsAndHashtags> res = await httpResponse.Content.ReadFromJsonAsync<Response<MentionsAndHashtags>>();
            return res;
        }
    }
}
