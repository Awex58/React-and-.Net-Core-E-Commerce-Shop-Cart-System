using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Dtos;
using Case1.Core.Entities.Results;
using Case1.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Shop_manager_system_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private IUserService _UserService;

        public AuthController(IUserService userService)
        {
            _UserService = userService;
           
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var userToLogin = _UserService.Login(userForLoginDto);


            if (userToLogin.Success == true)
            {

                return Ok(userToLogin);
            }
            else
            {
                return BadRequest();
            }

         
        }


    }
}
