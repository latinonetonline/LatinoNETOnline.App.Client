using System;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Users;

namespace LatinoNETOnline.App.Client.Core.Services
{
    public interface IUserClientService
    {
        Task<ResponseEnumerable<User>> GetUsersAsync();
        Task<Response<User>> GetUserAsync(Guid userId);
        Task<Response> DeleteUserAsync(Guid userId);
        Task<Response> CreateUserAsync(User user);
        Task<Response> UpdateUserAsync(User user);
    }
}
