using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace LatinoNETOnline.App.Client.Authentication
{
    public class AuthenticationTypeRequirement : AuthorizationHandler<AuthenticationTypeRequirement>, IAuthorizationRequirement
    {
        public AuthenticationTypeRequirement(params string[] authenticationTypes)
        {
            AuthenticationTypes = authenticationTypes;
        }

        public IEnumerable<string> AuthenticationTypes { get; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthenticationTypeRequirement requirement)
        {
            bool isAuthenticate = false;
            foreach (var authenticationType in requirement.AuthenticationTypes)
            {
                isAuthenticate = context.User.Identities.Any(x => x.AuthenticationType == authenticationType && x.IsAuthenticated);

                if (!isAuthenticate)
                {
                    break;
                }
            }

            if (isAuthenticate)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
