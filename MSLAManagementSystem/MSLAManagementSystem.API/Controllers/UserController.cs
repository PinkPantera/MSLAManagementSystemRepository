using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSLAManagementSystem.API.Validation;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Services;
using System.Threading.Tasks;

namespace MSLAManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("")]
        public async Task<ActionResult<UserModel>> AddUser(UserModel user)
        {
            var userValidation = new UserValidation();
            var resultValidation = await userValidation.ValidateAsync(user);

            if (!resultValidation.IsValid)
            {
                var error = $"{resultValidation.ToString("\n")}";
                return BadRequest(error);
            }

            await userService.CreateAsync(user);

           return Ok(user);
        }
    }
}
