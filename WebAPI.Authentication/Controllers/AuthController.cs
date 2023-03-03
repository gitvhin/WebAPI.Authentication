using Microsoft.AspNetCore.Mvc;
using WebAPI.Authentication.Repositories;

namespace WebAPI.Authentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserReporsitory userReporsitory;
        private readonly ITokenHandler tokenHandler;
        public AuthController(IUserReporsitory userReporsitory, ITokenHandler tokenHandler)
        {
            this.userReporsitory = userReporsitory;
            this.tokenHandler = tokenHandler;

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Model.DTO.LoginRequest loginRequest)
        {
            if (loginRequest.Username != string.Empty && loginRequest.Password != string.Empty)
            {
                var user = await userReporsitory.AuthenticateAsync(loginRequest.Username,
                    loginRequest.Password);

                if (user!= null)
                {
                    var token = await tokenHandler.CreateTokenAsync(user);
                    return Ok(token);
                }
            }
            return BadRequest("Username or Password is incorrect.");
        }
    }
}
