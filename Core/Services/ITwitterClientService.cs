using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Twitter;

namespace LatinoNETOnline.App.Client.Core.Services
{
    public interface ITwitterClientService
    {
        Task<Response<TweetResult>> CreateTweetAsync(CreateTweetRequest tweet);
        Task<Response<MentionsAndHashtags>> GetLastMentionsAndHashtagsAsync();
    }
}
