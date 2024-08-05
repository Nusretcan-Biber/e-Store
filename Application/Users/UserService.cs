using ApplicationShared.Services.Users;
using ApplicationShared.Users.Dtos;
using Core.BaseServices.Services;
using Data.Context;
using Domain;

namespace Application.Users
{
    public class UserService : BaseCrudAppService<PostgreDbContext,User, UserDto, CreateUserDto, UpdateUserDto>, IUserService
    {
    }
}
