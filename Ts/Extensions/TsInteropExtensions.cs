using LatinoNETOnline.App.Client.Ts.Services.Concretes;
using LatinoNETOnline.App.Client.Ts.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace LatinoNETOnline.App.Client.Ts.Extensions
{
    public static class TsInteropExtensions
    {
        public static IServiceCollection AddTsInteropServices(this IServiceCollection services)
        {
            services.AddSingleton<ICanvasInteropService, CanvasInteropService>();
            services.AddSingleton<ICommonInteropService, CommonInteropService>();
            services.AddSingleton<IInputInteropService, InputInteropService>();

            return services;
        }
    }
}
