using Microsoft.AspNetCore.Http;
using StockFlow.Models;
using Microsoft.AspNetCore.Mvc;
using StockFlow.Services;
using System.Reflection.PortableExecutable;
using StockFlow.Dtos.User;
using StockFlow.Dtos;

namespace StockFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<GetUserResponse>>> GetUsers() => Ok(await service.GetAllUsersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserResponse>> GetUser(Guid id)
        {
            var user = await service.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound("User with the given id was not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<GetUserResponse>> CreateUser(CreateUserRequest request)
        {
            var createdUser = await service.CreateUserAsync(request);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, UpdateUserRequest request)
        {
            var updatedUser = await service.UpdateUserAsync(id, request);
            return updatedUser ? Ok("Update Success") : NotFound("User with given Id was not found.");
        }

        [HttpDelete("{id}")]
            public async Task<ActionResult<ResponseAPI<object>>> DeleteUser(Guid id)
            {
                var deletedUser = await service.DeleteUserAsync(id);
                if (!deletedUser)
                {
                return NotFound(new ResponseAPI<object>
                {
                    Error = true,
                    Status = StatusCodes.Status404NotFound,
                    Message = "User with the given Id was not found"
                });
                }

                return Ok(new ResponseAPI<object>
                {
                    Error = false,
                    Status = StatusCodes.Status200OK,
                    Message = "User succesfully deleted"
                });
        }
    }
}
