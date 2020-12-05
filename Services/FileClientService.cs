using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

using BlazorJsFastDataExchanger;

using LatinoNETOnline.App.Client.Core.Models.Eventbrite;
using LatinoNETOnline.App.Client.Core.Services;

using Microsoft.JSInterop;

namespace LatinoNETOnline.App.Client.Services
{
    public class FileClientService : IFileClientService
    {
        private readonly HttpClient _httpClient;

        private readonly IJSRuntime _jsRuntime;

        public FileClientService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        public string GetFileBase64(string variableName)
        {
            int l = JsFastDataExchanger.GetBinaryDataLenght(variableName);

            byte[] file = new byte[l];

            JsFastDataExchanger.GetBinaryData(variableName, file);
            return Convert.ToBase64String(file);
        }

        public async ValueTask<bool> HasFileAsync(string inputFileElementId)
        {
            return await _jsRuntime.InvokeAsync<bool>("LocalJsFunctions.HasFile", inputFileElementId);
        }

        public async ValueTask<bool> ReadFileAsync(string variableName, string inputFileElementId)
        {
            return await _jsRuntime.InvokeAsync<bool>("LocalJsFunctions.ReadFile", variableName, inputFileElementId);
        }

        public async ValueTask<Logo> UploadImageAsync(string variableName)
        {
            //https://github.com/Lupusa87/BlazorJsFastDataExchanger/blob/master/README.md
            int l = JsFastDataExchanger.GetBinaryDataLenght(variableName);

            byte[] image = new byte[l];

            JsFastDataExchanger.GetBinaryData(variableName, image);

            using MultipartFormDataContent form = new MultipartFormDataContent();

            using ByteArrayContent fileContent = new ByteArrayContent(image);

            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            form.Add(fileContent, "file", "file");

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "api/eventbrite/UpdateMedia")
            {
                Content = form
            };

            var httpResponseStep = await _httpClient.SendAsync(httpRequestMessage);

            httpResponseStep.EnsureSuccessStatusCode();

            return await httpResponseStep.Content.ReadFromJsonAsync<Logo>();
        }
    }
}
