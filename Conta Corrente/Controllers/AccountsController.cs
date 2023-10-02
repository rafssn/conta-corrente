using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infra.Helpers;
using Domain.Data;
using System.Security.Claims;

namespace Conta_Corrente.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IList<Account>>> Get([FromServices] DataContext context)
        {
            var accounts = await context
            .Accounts
                .Where(x => x.UserId == UserHelper.GetUserId(User))
                .Include(x => x.Movements)
                .AsNoTracking()
                .ToListAsync();

            if (!accounts.Any())
                return StatusCode(404, "Not found");

            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetById([FromRoute] int id,
            [FromServices] DataContext context)
        {
            var account = await context
            .Accounts
            .Include(x => x.Movements)
            .FirstOrDefaultAsync(x => x.UserId == UserHelper.GetUserId(User) && x.Id == id);

            if (account is null)
                return StatusCode(404, "Not found");

            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<Account>> Post([FromServices] DataContext context)
        {
            var user = await context
            .Users
            .FirstOrDefaultAsync(x => x.Id == UserHelper.GetUserId(User));

            if (user is null)
                return BadRequest("User not exists");

            var account = Account.Create(user);

            await context.Accounts.AddAsync(account);
            await context.SaveChangesAsync();

            return StatusCode(201, account);
        }
    }
}
