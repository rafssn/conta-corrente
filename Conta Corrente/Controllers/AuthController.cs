using Infra;
using Conta_Corrente.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using Domain.Data;

namespace Conta_Corrente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(
        [FromBody] LoginViewModel model,
        [FromServices] DataContext context,
        [FromServices] TokenService tokenService)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var user = await context
                .Users
                .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null)
                return StatusCode(401, "User or password invalid");

            if (!PasswordHasher.Verify(user.PasswordHash, model.Password))
                return StatusCode(401, "User or password invalid");

            try
            {
                var token = tokenService.GenerateToken(user);
                return Ok(new { token });
            }
            catch
            {
                return StatusCode(500, "Internal Error");
            }
        }
    }
}