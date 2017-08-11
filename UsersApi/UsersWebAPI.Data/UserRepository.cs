using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebAPI.Data
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetAllUsersAsync()
        {
            using (UserContext db = new UserContext())
            {
                return await db.Users.ToListAsync();
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            using (UserContext db = new UserContext())
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null)
                {
                    return false;
                }
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> EditUserAsync(User user)
        {
            using (UserContext db = new UserContext())
            {
                User dbuser = await db.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                if (user == null)
                {
                    return false;
                }
                dbuser.DepartmentId = user.DepartmentId;
                dbuser.UserName = user.UserName;
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<User> CreateUser(User user)
        {
            using (UserContext db = new UserContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                user = db.Users.OrderByDescending(u => u.Id).First();
            }
            return user;
        }
    }
}
