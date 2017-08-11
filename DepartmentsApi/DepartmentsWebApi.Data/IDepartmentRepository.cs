using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepartmentsWebApi.Data
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentsAsync();
    }
}
