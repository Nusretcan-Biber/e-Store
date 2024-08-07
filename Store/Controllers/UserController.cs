using Application.Users;
using ApplicationShared.Services.Users;
using ApplicationShared.Users.Dtos;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private UserService userservice;

        public UserController(IUserService _userService, UserService userservice)
        {
            this._userService = _userService;
            this.userservice = userservice;
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
            var result = await _userService.GetAsync(guid);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpPost(nameof(InsertUser))]
        public async Task<ActionResult> InsertUser(CreateUserDto createUserDto)
        {
            try
            {
                var result = await userservice.InsertAsync(createUserDto);

                if (result > 0)
                {
                    // Ekleme başarılı oldu, uygun bir yanıt döndür
                    return Ok(new { Message = "User created successfully", UserId = result });
                }
                else
                {
                    // Ekleme başarısız oldu, uygun bir hata yanıtı döndür
                    return StatusCode(500, "An error occurred while creating the user");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda genel bir hata yanıtı döndür
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }

        [HttpDelete(nameof(DeleteUser))]
        public async Task<ActionResult<IEnumerable<UserDto>>> DeleteUser(Guid guid)
        {
            var result = await _userService.DeleteAsync(guid);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }
        [HttpPut(nameof(UpdateUser))]
        public async Task<ActionResult<IEnumerable<UserDto>>> UpdateUser(Guid guid,CreateUserDto userDto)
        {
            userDto.Guid = guid;
            var result = await userservice.UpdateAsync(userDto);
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }




    }
}
