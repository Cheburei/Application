using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DepartmentsWebApi.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            using (DepartmentContext db = new DepartmentContext())
            {
                return await db.Departments.ToListAsync();
            }
        }
    }
}
