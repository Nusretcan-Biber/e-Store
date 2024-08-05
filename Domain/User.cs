using Core.BaseEntities;
using DomainShared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string SurName { get; set; }
        public virtual string Password { get; set; }
        public virtual string? Email { get; set; }
        public virtual UserRoleType UserRoleType { get; set; }

        internal User() { }

        public User([NotNull] string name,
                    [NotNull] string surName,
                    [NotNull] string password,
                    UserRoleType userRoleType)
        {
            Name = name;
            SurName = surName;
            Password = password;
            UserRoleType = userRoleType;
        }
    }
}
