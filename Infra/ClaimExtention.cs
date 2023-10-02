using Domain.Entities;
using System.Security.Claims;

namespace Infra
{
    public static class ClaimExtention
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            return result;
        }
    }
}
