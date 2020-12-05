using System.Collections.Generic;

namespace LatinoNETOnline.App.Client.Authentication
{
    public class AuthenticationStateData
    {
        public bool IsAuthenticated { get; set; }

        public List<ExposedClaim> Claims { get; set; }
    }
}
