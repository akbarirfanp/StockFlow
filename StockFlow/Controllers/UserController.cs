using Microsoft.AspNetCore.Http;
using StockFlow.Models;
using Microsoft.AspNetCore.Mvc;
using StockFlow.Services;
using System.Reflection.PortableExecutable;

namespace StockFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers() => Ok(await service.GetAllUsersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await service.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound("User with the given id was not found");
            }
            return Ok(user);
        }
    }
}
