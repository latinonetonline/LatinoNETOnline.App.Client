using LatinoNETOnline.App.Client.Authentication.Extensions;
using LatinoNETOnline.App.Client.Core.Enums;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace LatinoNETOnline.App.Client.Authentication
{
    public static class Policies
    {
        public static AuthorizationPolicy IsSpeaker()
        {
            AuthorizationPolicyBuilder authorizationPolicyBuilder = new AuthorizationPolicyBuilder();
            authorizationPolicyBuilder.Requirements.Add(new RolesAuthorizationRequirement(UserRole.Speaker.GetNamesGreaterOrEqualsRoles()));

            return authorizationPolicyBuilder.Build();
        }

        public static AuthorizationPolicy IsOrganizer()
        {
            AuthorizationPolicyBuilder authorizationPolicyBuilder = new AuthorizationPolicyBuilder();
            authorizationPolicyBuilder.Requirements.Add(new RolesAuthorizationRequirement(UserRole.Organizer.GetNamesGreaterOrEqualsRoles()));

            return authorizationPolicyBuilder.Build();
        }

        public static AuthorizationPolicy IsAdmin()
        {
            AuthorizationPolicyBuilder authorizationPolicyBuilder = new AuthorizationPolicyBuilder();
            authorizationPolicyBuilder.Requirements.Add(new RolesAuthorizationRequirement(UserRole.Admin.GetNamesGreaterOrEqualsRoles()));

            return authorizationPolicyBuilder.Build();
        }
    }
}
