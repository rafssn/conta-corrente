using Domain.Entities;
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
    public class RegisterController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model,
                                      [FromServices] DataContext context)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new User(model.Email, model.Name, PasswordHasher.Hash(model.Password));

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok($"{user.Email} {user.PasswordHash}");
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, "Duplicate Email");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
