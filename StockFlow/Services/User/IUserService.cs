namespace StockFlow.Services.User;
using StockFlow.Dtos.User;   

public interface IUserService
{   
    Task<List<GetUserResponse?>> GetAllUsersAsync();
    // ? means could be null
    Task<GetUserResponse?> GetUserByIdAsync(Guid id);
    Task<CreateUserResponse?> CreateUserAsync(CreateUserRequest request);
    Task<bool> UpdateUserAsync(Guid id, UpdateUserRequest request);
    Task<bool> DeleteUserAsync(Guid id);
}
