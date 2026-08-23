using FluentValidation; // Install this from NuGet Package
namespace StockFlow.Dtos.User

{
    public class CreateUserRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class CreateUserValidation : AbstractValidator<CreateUserRequest>
    { 
        public CreateUserValidation() { 
        }
    }

}
