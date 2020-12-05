using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LatinoNETOnline.App.Client.Ts.Services.Interfaces
{
    public interface ICanvasInteropService
    {
        ValueTask AddPasteEventListener<TValue>(ElementReference canvas, ElementReference fileInput, DotNetObjectReference<TValue> dotNetObjectReference) where TValue : class;
        ValueTask<string> GetCanvasBase64(ElementReference canvas);
        ValueTask SetBase64IntoCanvas<TValue>(ElementReference canvas, string imageBase64, DotNetObjectReference<TValue> dotNetObjectReference) where TValue : class;
    }
}
