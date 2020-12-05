using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Ts.Services.Interfaces;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LatinoNETOnline.App.Client.Ts.Services.Concretes
{
    public class CanvasInteropService : ICanvasInteropService
    {
        private readonly IJSRuntime _jsRuntime;

        public CanvasInteropService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask AddPasteEventListener<TValue>(ElementReference canvas, ElementReference fileInput, DotNetObjectReference<TValue> dotNetObjectReference) where TValue : class
        {
            return _jsRuntime.InvokeVoidAsync("CanvasInteropFunctions.addPasteEventListener", canvas, fileInput, dotNetObjectReference);
        }

        public async ValueTask<string> GetCanvasBase64(ElementReference canvas)
        {
            return await _jsRuntime.InvokeAsync<string>("CanvasInteropFunctions.getCanvasBase64", canvas);
        }

        public ValueTask SetBase64IntoCanvas<TValue>(ElementReference canvas, string imageBase64, DotNetObjectReference<TValue> dotNetObjectReference) where TValue : class
        {
            return _jsRuntime.InvokeVoidAsync("CanvasInteropFunctions.setBase64IntoCanvas", canvas, imageBase64, dotNetObjectReference);
        }
    }
}
