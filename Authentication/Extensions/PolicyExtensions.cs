using LatinoNETOnline.App.Client.Core.Models;

using Microsoft.Extensions.DependencyInjection;

namespace LatinoNETOnline.App.Client.Authentication.Extensions
{
    public static class PolicyExtensions
    {
        public static IServiceCollection AddAuthenticationCorePolicy(this IServiceCollection services)
        {
            return services.AddAuthorizationCore(config =>
            {
                config.AddPolicy(PolicieRoles.Speaker, Policies.IsSpeaker());
                config.AddPolicy(PolicieRoles.Organizer, Policies.IsOrganizer());
                config.AddPolicy(PolicieRoles.Admin, Policies.IsAdmin());
                config.InvokeHandlersAfterFailure = false;
            });
        }
    }
}
