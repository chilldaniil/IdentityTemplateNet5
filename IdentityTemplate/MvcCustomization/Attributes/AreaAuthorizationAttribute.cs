using Microsoft.AspNetCore.Authorization;

namespace IdentityTemplate.MvcCustomization.Attributes
{
    public class AreaAuthorizationAttribute : AuthorizeAttribute
    {
        public AreaAuthorizationAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}
