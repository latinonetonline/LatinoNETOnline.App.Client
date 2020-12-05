using System.Threading.Tasks;

namespace LatinoNETOnline.App.Client.Ts.Services.Interfaces
{
    public interface ICommonInteropService
    {
        ValueTask CopyText(string text);
    }
}
