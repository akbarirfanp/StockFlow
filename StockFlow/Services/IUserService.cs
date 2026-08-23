namespace StockFlow.Services;
using StockFlow.Dtos.User;   

public interface IUserService
{   
    Task<List<GetUserResponse?>> GetAllUsersAsync();
    // ? means could be null
    Task<GetUserResponse?> GetUserByIdAsync(Guid id);
    Task<GetUserResponse?> CreateUserAsync(CreateUserRequest request);
    Task<bool> UpdateUserAsync(Guid id, UpdateUserRequest request);
    Task<bool> DeleteUserAsync(Guid id);
}
