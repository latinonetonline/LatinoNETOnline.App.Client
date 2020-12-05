using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Links;

namespace LatinoNETOnline.App.Client.Core.Services
{
    public interface ILinkClientService
    {
        Task<ResponseEnumerable<LinkModel>> GetAllAsync();
        Task<Response> CreateAsync(LinkModel model);
        Task<Response> DeleteAsync(string name);
        Task<Response> CopyLink(string link);
        Task<Response<LinkModel>> GetAsync(string name);
        Task<Response> UpdateAsync(LinkModel model);
    }
}
