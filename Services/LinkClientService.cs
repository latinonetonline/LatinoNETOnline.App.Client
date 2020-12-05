using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Links;
using LatinoNETOnline.App.Client.Core.Services;
using LatinoNETOnline.App.Client.Ts.Services.Interfaces;

namespace LatinoNETOnline.App.Client.Services
{
    public class LinkClientService : ILinkClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ICommonInteropService _jsRuntime;
        public LinkClientService(HttpClient httpClient, ICommonInteropService jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        public async Task<Response> CopyLink(string link)
        {
            await _jsRuntime.CopyText(link);
            return new Response
            {
                Success = true
            };
        }

        public async Task<Response> CreateAsync(LinkModel model)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync("api/Links", model);

            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response> UpdateAsync(LinkModel model)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync("api/Links", model);

            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response> DeleteAsync(string name)
        {
            var httpResponse = await _httpClient.DeleteAsync($"api/Links/{name}");
            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<ResponseEnumerable<LinkModel>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<ResponseEnumerable<LinkModel>>("api/Links");
        }

        public async Task<Response<LinkModel>> GetAsync(string name)
        {
            return await _httpClient.GetFromJsonAsync<Response<LinkModel>>($"api/Links/{name}");
        }
    }
}
