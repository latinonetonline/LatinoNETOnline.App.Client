using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.EasyCron;
using LatinoNETOnline.App.Client.Core.Services;

namespace LatinoNETOnline.App.Client.Services
{
    public class EasyCronClientService : IEasyCronClientService
    {
        private readonly HttpClient _httpClient;
        public EasyCronClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Response<CronJobResponse>> CreateJobAsync(CreateCronRequest request)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync("api/Links", request);

            var res = await httpResponse.Content.ReadFromJsonAsync<Response<CronJobResponse>>();
            return res;
        }

        public async Task<Response<CronJobResponse>> DeleteJobAsync(long cronId)
        {
            var httpResponse = await _httpClient.DeleteAsync($"api/easycron/{cronId}");
            var res = await httpResponse.Content.ReadFromJsonAsync<Response<CronJobResponse>>();
            return res;
        }

        public Task<Response<ListCronJob>> DetailJobAsync(long cronId)
        {
            return _httpClient.GetFromJsonAsync<Response<ListCronJob>>($"api/easycron/{cronId}");
        }

        public async Task<Response<CronJobResponse>> EditJobAsync(EditCronRequest request)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync("api/easycron", request);

            var res = await httpResponse.Content.ReadFromJsonAsync<Response<CronJobResponse>>();
            return res;
        }

        public Task<Response<ListCronJob>> ListJobAsync()
        {
            return _httpClient.GetFromJsonAsync<Response<ListCronJob>>($"api/easycron");
        }
    }
}
