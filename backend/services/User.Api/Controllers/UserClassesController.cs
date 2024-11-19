using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Api.Data;
using User.Api.Models;
using User.Api.Repository;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClassesController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserClassesController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/UserClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserClass>>> GetUsers()
        {
            var result= await _userRepository.getUser();
            if(result==null)
                return NotFound();
            return Ok(result);
        }

        // GET: api/UserClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserClass>> GetUserClass(int id)
        {
            var userClass =await _userRepository.getUserById(id);

            if (userClass == null)
            {
                return NotFound();
            }

            return userClass;
        }
        // POST: api/UserClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<ActionResult<UserClass>> PostUserClass(UserDto userClass)
        {
            var result = await _userRepository.createUser(userClass);

            return Ok(result);
        }
        // PUT: api/UserClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserClass(int id, UserDto user)
        {
            //var er = _context.Users.FindAsync(id);
            //if (er == null) { return NotFound(); }
            var result=await _userRepository.editProfile(id,user);
            if (result==null)
            {
                return BadRequest();
            }

            //_context.Entry(userClass).State = EntityState.Modified;
            //return Ok();
            return Ok(result);
        }   
        // DELETE: api/UserClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserClass(int id)
        {
            var result=await _userRepository.deleteUser(id);
            if (!result )/// result==null (dont do)
                return NotFound("User not found.");
            return Ok(result);
        }
        [HttpGet("id/{username}")]
        public async Task<ActionResult<int>> GetUserId(string username)
        {
            var userId = await _userRepository.getUserId(username);

            if (userId == 0)
            {
                return NotFound();
            }

            return userId;
        }

    }
}
