using System.Security.Claims;

namespace Infra.Helpers
{
    public class UserHelper
    {
        public static int GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
            return Convert.ToInt32(userId.Value);
        }
    }
}
