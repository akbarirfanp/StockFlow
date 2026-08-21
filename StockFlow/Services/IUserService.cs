namespace StockFlow.Services;

using StockFlow.Models;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    // ? means could be null
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(Guid id, User user);
    Task<bool> DeleteUserAsync(Guid id);
}
