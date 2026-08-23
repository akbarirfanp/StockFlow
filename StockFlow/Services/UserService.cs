using Microsoft.EntityFrameworkCore;
using StockFlow.Data;
using StockFlow.Dtos.User;
using StockFlow.Models;

namespace StockFlow.Services
{


    public class UserService(AppDbContext context) : IUserService // UserService that implements the interface (Interface classs use 'I' prefix)
    {
        public async Task<GetUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };
            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return new GetUserResponse
            {
                Name = newUser.Name,
                Email = newUser.Email,
                Password = newUser.Password
            };
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var existingUser = await context.Users.FindAsync(id);
            if (existingUser is null)
                return false;

            context.Users.Remove(existingUser);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetUserResponse>> GetAllUsersAsync() 
            => (await context.Users.ToListAsync()).Select(u => new GetUserResponse
            // use mapstar or automapper
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password
            }).ToList();

        public async Task<GetUserResponse?> GetUserByIdAsync(Guid id)
        {
            var u = await context.Users.FindAsync(id);
            if (u is null) return null;
            return new GetUserResponse
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password
            };
        }

        public async Task<bool> UpdateUserAsync(Guid id, UpdateUserRequest request)
        {
            var existingUser = await context.Users.FindAsync(id); // Find id of the user
            if (existingUser is null)
            {
                return false;
            }
            existingUser.Name = request.Name;
            existingUser.Email= request.Email;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
