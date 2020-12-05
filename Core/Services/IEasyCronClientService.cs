using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.EasyCron;

namespace LatinoNETOnline.App.Client.Core.Services
{
    public interface IEasyCronClientService
    {
        Task<Response<CronJobResponse>> CreateJobAsync(CreateCronRequest request);
        Task<Response<CronJobResponse>> EditJobAsync(EditCronRequest request);
        Task<Response<ListCronJob>> DetailJobAsync(long cronId);
        Task<Response<CronJobResponse>> DeleteJobAsync(long cronId);
        Task<Response<ListCronJob>> ListJobAsync();
    }
}
