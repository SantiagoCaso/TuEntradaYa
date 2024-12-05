using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuEntradaYa.Models.Dtos.User;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        [Authorize(Policy = "Admin")]
        public ActionResult<List<Users>> GetAllUsers()
        {
            var allUsers = _userService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "Admin")]
        public ActionResult<Users?> GetUserById(int id)
        {
            var user =  _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("new-user")]
        public IActionResult AddUser([FromBody] UserCreateDto newUser)
        {
            bool userCreated = _userService.AddUser(newUser);
            return Ok("Se a creado el usuario " + newUser.Name);
        }

        [Authorize]
        [HttpPut("update-user/{email}")]
        public IActionResult UpdateUser(string email, string password, [FromBody] UserUpateDto user)
        {
            try
            {
                bool userUpdate = _userService.UpdateUser(email, password, user);
                return Ok("El usuario se a actualizado con exitoooooooo!");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            
        }

        [HttpDelete("delete-user")]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteUser(int userId)
        {
            bool userIsDelete = _userService.DeleteUser(userId);
            if (!userIsDelete) 
            {
                return Ok("El usuario no se ha eliminado");
            }

            return Ok("El usuario se ha eliminado"); 
        }

        [HttpGet("by-email/{email}")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetUserByEmail(string email)
        {
            var user =  _userService.GetUserByEmail(email);
            

            return Ok(user);
        }

        [HttpGet("username")]
        [Authorize(Policy = "Admin")]
        public  ActionResult<Users?> GetUserByUsername(string username)
        {
            var user = _userService.GetUserByUsername(username);
            return Ok(user);
        }

    }
}
