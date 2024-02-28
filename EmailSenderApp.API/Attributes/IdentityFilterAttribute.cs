using EmailSenderApp.Domain.Entites.AuthModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Security;
using System.Security.Claims;
using System.Text.Json;

namespace EmailSenderApp.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Enum)]
    public class IdentityFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _permission;
        public IdentityFilterAttribute(Permission permission)
        {
            _permission = (int)permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;

            var permissionsIds = identity.FindFirst("Permissions")?.Value;

            var ids = JsonSerializer.Deserialize<List<int>>(permissionsIds).Any(x => x == _permission);
            if (!ids)
            {
                context.Result=new ForbidResult();
                return;
            }

            
        }
    }
}
