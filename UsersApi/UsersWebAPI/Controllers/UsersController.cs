using System;
using System.Threading.Tasks;
using System.Web.Http;
using UsersWebAPI.Data;

namespace UsersWebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                return Ok(await _userRepository.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            try
            {
                bool result = await _userRepository.DeleteUserAsync(id);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> EditUser([FromBody] User user)
        {
            try
            {
                bool result = await _userRepository.EditUserAsync(user);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                User newUser = await _userRepository.CreateUser(user);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
