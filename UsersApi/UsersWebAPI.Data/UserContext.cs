using System.Data.Entity;

namespace UsersWebAPI.Data
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=UsersDb") { }

        public DbSet<User> Users { get; set; }
    }
}
