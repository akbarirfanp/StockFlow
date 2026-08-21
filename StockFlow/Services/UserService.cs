using StockFlow.Models;

namespace StockFlow.Services
{


    public class UserService : IUserService // UserService that implements the interface (Interface classs use 'I' prefix)
    {
        static List<User> users = new List<User>
        {
             new User {Id = Guid.NewGuid(), Name = "Irfan", Email = "akbarirfanp@gmail.com", Password = "@StockFlow123"},
             new User {Id = Guid.NewGuid(), Name = "Wiwik", Email = "wiwiksatiaraj@gmail.com", Password = "@StockFlow123"},
             new User {Id = Guid.NewGuid(), Name = "Wiwik", Email = "wiwiksatiaraj@gmail.com", Password = "@StockFlow123"}

        };
        public Task<User> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsersAsync() => await Task.FromResult(users);

        public Task<User?> GetUserByIdAsync(Guid id)
        {
            var result = users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(result);
        }

        public Task<bool> UpdateUserAsync(Guid id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
