using ApplicationShared.Mapper;
using ApplicationShared.Services.Users;
using ApplicationShared.Users.Dtos;
using Core.BaseServices.Services;
using Data.Context;
using Domain;

namespace Application.Users
{
    public class UserService : BaseCrudAppService<PostgreDbContext,User, UserDto, CreateUserDto, UpdateUserDto> , IUserService
    {
        public  async Task<int> InsertAsync(CreateUserDto createUserDto)
        {
            var createUser = MappingProfile<CreateUserDto, User>.Instance.Mapper.Map<User>(createUserDto);
            createUser.UserRoleType = DomainShared.UserRoleType.CUSTOMER;

            // | DomainShared.UserRoleType.SELLER;
            return await base.InsertAsync(createUser);
        }
        public  async Task<int> UpdateAsync(CreateUserDto updateInput)
        {

            var updateUser = MappingProfile<CreateUserDto, User>.Instance.Mapper.Map<User>(updateInput);
            updateUser.UpdatedDate= DateTime.UtcNow;
            updateUser.IsUpdated = true;

            return await base.UpdateAsync(updateUser);
        }









    }
}
