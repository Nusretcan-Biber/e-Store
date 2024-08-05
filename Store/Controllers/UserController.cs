using ApplicationShared.Services.Users;
using ApplicationShared.Users.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet(nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var result = _userService.GetAll();
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }


        [HttpGet(nameof(Get))]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get(Guid guid)
        {
            var result = _userService.Get(guid);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

    }
}
