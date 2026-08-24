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
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(64);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }

}




