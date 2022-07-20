using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolSendMail.Data;
using ToolSendMail.Models;
using ToolSendMail.Repository;

namespace ToolSendMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository userRepository;

        /// <summary>
        /// Initialization User Controller
        /// </summary>
        /// <param name="context"></param>
        public UsersController(EntityContext context)
        {
            userRepository = new UserRepository(context);
        }

        /// <summary>
        /// Get list Users in API
        /// GET: api/Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            List<User> listUser = new List<User>();
            foreach (Object obj in await userRepository.GetAllEntityAsync())
            {
                listUser.Add(obj as User);
            }
            return listUser;
        }

        /// <summary>
        /// get User in API
        /// GET: api/Users/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await userRepository.GetEntityByIdAsync(id) as User;
        }

        /// <summary>
        /// Update API
        /// PUT: api/Users/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            try
            {
                await userRepository.UpdateEntityAsync(id, user);
            }
            catch
            {

            }
            return NoContent();
        }

        /// <summary>
        /// Create new User
        /// POST: api/Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User</returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            return await userRepository.CreateEntityAsync(user) as User;
        }

        /// <summary>
        /// Delete User on API
        /// DELETE: api/Users/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await userRepository.DeleteEntityById(id);
            }
            catch
            {

            }
            return NoContent();
        }
    }
}
