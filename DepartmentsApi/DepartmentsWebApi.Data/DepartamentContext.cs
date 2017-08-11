using System.Data.Entity;

namespace DepartmentsWebApi.Data
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext(): base("name=DepartmentDb") {}
        public DbSet<Department> Departments { get; set; }
    }
}
