using Core.BaseDtos;

namespace ApplicationShared.Users.Dtos
{
    public class UserDto : BaseDto
    {
        public virtual string Name { get; set; }
        public virtual string SurName { get; set; }
        public virtual string Password { get; set; }
        public virtual string? Email { get; set; }
    }
}
