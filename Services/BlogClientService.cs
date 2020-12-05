using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Blog;
using LatinoNETOnline.App.Client.Core.Services;

namespace LatinoNETOnline.App.Client.Services
{
    public class BlogClientService : IBlogClientService
    {
        private readonly HttpClient _httpClient;
        public BlogClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<Article>> GetArticleAsync(string slug)
        {
            var httpResponse = await _httpClient.GetAsync($"api/blog/article/{slug}");
            return await httpResponse.Content.ReadFromJsonAsync<Response<Article>>();
        }

        public async Task<Response<ArticleExist>> IsPublish(string slug)
        {
            var httpResponse = await _httpClient.GetAsync($"api/blog/article/GetArticlePublished/{slug}");
            Response<ArticleExist> response = await httpResponse.Content.ReadFromJsonAsync<Response<ArticleExist>>();

            return response;
        }

        public async Task<Response> Publish(string slug)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync($"api/blog/article/Publish", new PublishArticleHttpRequest { Slug = slug });
            Response response = await httpResponse.Content.ReadFromJsonAsync<Response>();

            return response;
        }

        public async Task<Response> UpdateArticleAsync(Article article)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync("api/Blog/Article", article);
            return await httpResponse.Content.ReadFromJsonAsync<Response>();
        }
    }
}
