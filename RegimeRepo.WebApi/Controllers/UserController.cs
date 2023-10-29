using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegimeRepo.WebApi.Businnes.Abstract;
using RegimeRepo.WebApi.Entites.Concrete;

namespace RegimeRepo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser(UserEntity ent)
        {
            await _userService.Add(ent);
            return Ok();
        }
    }
}
