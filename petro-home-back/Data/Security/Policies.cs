using Microsoft.AspNetCore.Authorization;

namespace petro_home_back.Data.Security
{
    public class Policies
    {
        public const string ADMIN = "ADMIN";
        public const string USER = "USER";

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(ADMIN).Build();
        }
        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(USER).Build();
        }
    }
}
