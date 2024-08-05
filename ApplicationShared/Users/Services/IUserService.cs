using ApplicationShared.Users.Dtos;
using Core.BaseServices.Interfaces;
using Domain;

namespace ApplicationShared.Services.Users
{
    public interface IUserService : IBaseCrudAppService<User, UserDto, CreateUserDto, UpdateUserDto>
    {

    }
}
