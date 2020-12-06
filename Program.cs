using System;
using System.Net.Http;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Authentication;
using LatinoNETOnline.App.Client.Authentication.Extensions;
using LatinoNETOnline.App.Client.Core.Services;
using LatinoNETOnline.App.Client.Security;
using LatinoNETOnline.App.Client.Services;
using LatinoNETOnline.App.Client.Ts.Extensions;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LatinoNETOnline.App.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddSingleton<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            //builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IEventClientService, EventClientService>();
            builder.Services.AddSingleton<IUserClientService, UserClientService>();
            builder.Services.AddSingleton<IPollClientService, PollClientService>();
            builder.Services.AddSingleton<IBlogClientService, BlogClientService>();
            builder.Services.AddSingleton<IFileClientService, FileClientService>();
            builder.Services.AddSingleton<ILinkClientService, LinkClientService>();
            builder.Services.AddSingleton<IEventbriteClientService, EventbriteClientService>();
            builder.Services.AddSingleton<ITwitterClientService, TwitterClientService>();
            builder.Services.AddSingleton<IEasyCronClientService, EasyCronClientService>();

            builder.Services.AddTsInteropServices();

            builder.Services.AddHttpClient("api", o => o.BaseAddress = new(builder.Configuration["api:BaseAddress"]))
                .AddHttpMessageHandler(sp =>
                {
                    var handler = sp.GetService<AuthorizationMessageHandler>()
                        .ConfigureHandler(
                            authorizedUrls: new[] { builder.Configuration["api:BaseAddress"] },
                            scopes: new[] { "TokenRefresherApi",
                                              "PollApi",
                                              "YoutubeApi",
                                              "TelegramBotApi",
                                              "IdentityServerApi",
                                              "LatinoNetOnlineApi",
                            });

                    return handler;
                });

            builder.Services.AddSingleton(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));

            builder.Services
               .AddOidcAuthentication(options =>
               {
                   builder.Configuration.Bind("oidc", options.ProviderOptions);
                   options.UserOptions.RoleClaim = "role";
               })
               .AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();


            builder.Services.AddOptions();

            builder.Services.AddAuthenticationCorePolicy();
            await builder.Build().RunAsync();
        }
    }
}
