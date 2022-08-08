using Microsoft.AspNetCore.Authorization;

namespace PeliculasAPI.Tests.Helpers
{
    public class AllowAnonymousHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            foreach (var requirement in context.PendingRequirements.ToList())
            {
                context.Succeed(requirement); //indicamos que el usuario cumple con los requerimientos
            }

            return Task.CompletedTask;
        }
    }
}
