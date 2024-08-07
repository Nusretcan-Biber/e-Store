using Core.BaseDtos;
using DomainShared;

namespace ApplicationShared.Users.Dtos
{
    public class CreateUserDto : BaseDto
    {
        public virtual string Name { get; set; }
        public virtual string SurName { get; set; }
        public virtual string Password { get; set; }
        public virtual string? Email { get; set; }
       // public virtual UserRoleType UserRoleType { get; set; } = UserRoleType.CUSTOMER;

    }
}
