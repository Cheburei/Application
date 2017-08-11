using DepartmentsWebApi.Data;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace DepartmentsWebApi.Controllers
{
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                return Ok(await _departmentRepository.GetAllDepartmentsAsync());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
