using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Ts.Services.Interfaces;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LatinoNETOnline.App.Client.Ts.Services.Concretes
{
    class InputInteropService : IInputInteropService
    {
        private readonly IJSRuntime _jsRuntime;

        public InputInteropService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }


        public ValueTask<string> GetTextAsync(ElementReference elementReference)
        {
            return _jsRuntime.InvokeAsync<string>("InputFunction.GetText", elementReference);
        }

        public ValueTask SetKeyUpDelegateAsync<TValue>(ElementReference elementReference, DotNetObjectReference<TValue> dotNetReference) where TValue : class
        {
            return _jsRuntime.InvokeVoidAsync("InputFunction.SetKeyUpDelegate", elementReference, dotNetReference);
        }
    }
}
