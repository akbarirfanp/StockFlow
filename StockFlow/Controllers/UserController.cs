using Microsoft.AspNetCore.Mvc;
using StockFlow.Services;
using StockFlow.Dtos.User;
using StockFlow.Dtos;
using FluentValidation;
using Microsoft.Extensions.Validation;

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
        public async Task<ActionResult<GetUserResponse>> CreateUser(CreateUserRequest request, IValidator<CreateUserRequest> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return BadRequest(new ErrorResponse<object>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Validation failed",
                    Errors = validationResult.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => e.ErrorMessage).ToArray()
                        )
                });
            }

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
            public async Task<ActionResult> DeleteUser(Guid id)
            {
                var deletedUser = await service.DeleteUserAsync(id);
                if (!deletedUser)
                {
                return NotFound(new ErrorResponse<object>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "User with given Id was not found"
                });
                }

                return Ok(new SuccessResponse<object>
                {
                    Error = false,
                    Status = StatusCodes.Status200OK,
                    Message = "User succesfully deleted"
                });
        }
    }
}
