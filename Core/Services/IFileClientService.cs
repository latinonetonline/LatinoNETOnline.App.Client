using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models.Eventbrite;

namespace LatinoNETOnline.App.Client.Core.Services
{
    public interface IFileClientService
    {
        ValueTask<bool> HasFileAsync(string inputFileElementId);
        ValueTask<bool> ReadFileAsync(string variableName, string inputFileElementId);
        string GetFileBase64(string variableName);
        ValueTask<Logo> UploadImageAsync(string variableName);
    }
}
