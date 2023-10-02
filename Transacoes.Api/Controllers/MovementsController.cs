using Domain.Data;
using Domain.Entities;
using Infra.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transacoes.Api.Models;

namespace Transacoes.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MovementsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovementViewModel movementVM,
            [FromServices] DataContext context)
        {
            var account = await context.Accounts
                .FirstOrDefaultAsync(x => x.Id == movementVM.AccountId);

            if(account == null || account.UserId != UserHelper.GetUserId(User))
                return BadRequest("Invalid account.");

            var movement = Movement.Create(movementVM.Type, movementVM.Value, account);

            try
            {
                var newBalance = Account.UpdateBalance(account, movement);

                await context.Movements
                    .AddAsync(Movement.Create(movement.Type, movement.Value, account));

                context.Accounts
                    .Update(newBalance);

                await context.SaveChangesAsync();

                return StatusCode(201, movement);
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
