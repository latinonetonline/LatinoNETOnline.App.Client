using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LatinoNETOnline.App.Client.Ts.Services.Interfaces
{
    public interface IInputInteropService
    {
        ValueTask<string> GetTextAsync(ElementReference elementReference);
        ValueTask SetKeyUpDelegateAsync<TValue>(ElementReference elementReference, DotNetObjectReference<TValue> dotNetReference) where TValue : class;
    }
}
