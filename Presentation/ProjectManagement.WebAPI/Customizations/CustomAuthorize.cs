using Microsoft.AspNetCore.Authorization;
using ProjectManagement.Domain.Enums;

namespace ProjectManagement.WebAPI.Customizations
{
    public class CustomAuthorize:AuthorizeAttribute
    {
        public CustomAuthorize(params Role[] allowedRoles)
        {
            var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(Role), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
