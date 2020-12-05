using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Ts.Services.Interfaces;

using Microsoft.JSInterop;

namespace LatinoNETOnline.App.Client.Ts.Services.Concretes
{
    public class CommonInteropService : ICommonInteropService
    {
        private readonly IJSRuntime _jsRuntime;

        public CommonInteropService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask CopyText(string text)
        {
            return _jsRuntime.InvokeVoidAsync("BzCopyBoardFunction.CopyText", text);
        }
    }
}
