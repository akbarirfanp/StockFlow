using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using StockFlow.Data;
using StockFlow.Dtos.User;
using StockFlow.Models;
using UserModel = StockFlow.Models.User;            

namespace StockFlow.Services.User
{


    public class UserService(AppDbContext context) : IUserService // UserService that implements the interface (Interface classs use 'I' prefix)
    {
        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var passwordHasher = new PasswordHasher<UserModel>();
            var newUser = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                CreatedAt = DateTime.Now,
                RoleId = request.RoleId
            };

            newUser.Password = passwordHasher.HashPassword(newUser, request.Password);
            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return new CreateUserResponse
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                CreatedAt = newUser.CreatedAt,
                RoleId = newUser.RoleId
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
        {
            return await context.Users
                .AsNoTracking()
                .Select(u => new GetUserResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    RoleId = u.RoleId,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<GetUserResponse?> GetUserByIdAsync(Guid id)
        {
            var u = await context.Users.FindAsync(id);
            if (u is null) return null;
            return new GetUserResponse
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
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
