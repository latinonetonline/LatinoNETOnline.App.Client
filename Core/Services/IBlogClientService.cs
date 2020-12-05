using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Blog;

namespace LatinoNETOnline.App.Client.Core.Services
{
    public interface IBlogClientService
    {
        Task<Response<Article>> GetArticleAsync(string slug);
        Task<Response> UpdateArticleAsync(Article article);
        Task<Response<ArticleExist>> IsPublish(string slug);
        Task<Response> Publish(string slug);
    }
}
