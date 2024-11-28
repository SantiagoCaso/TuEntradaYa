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
        public ActionResult<List<Users>> GetAllUsers()
        {
            var allUsers = _userService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("{id}")]
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

        [HttpPut("update-user")]
        public IActionResult UpdateUser([FromBody] UserUpateDto user)
        {
            bool userUpdate = _userService.UpdateUser(user);
            return Ok("El usuario se a actualizado con exitoooooooo!");
        }

        [HttpDelete("delete-user")]
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
        public IActionResult GetUserByEmail(string email)
        {
            var user =  _userService.GetUserByEmail(email);
            

            return Ok(user);
        }

        [HttpGet("username")]
        public  ActionResult<Users?> GetUserByUsername(string username)
        {
            var user = _userService.GetUserByUsername(username);
            return Ok(user);
        }

    }
}
