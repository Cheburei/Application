using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsersWebAPI.Data
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(int id);
        Task<bool> EditUserAsync(User user);
        Task<User> CreateUser(User user);
    }
}
