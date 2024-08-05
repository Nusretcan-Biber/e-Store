using Data.Configuration.BaseConfiguration;
using Domain;
using DomainShared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public DbSet<User> Users { get; set; }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserRoleType).HasConversion<short>();
            builder.HasData(
                new User("root", "toor", "root", UserRoleType.OWNER)
                {
                    Guid = Guid.Parse("a49c7554-02c0-4057-8173-fc7275741137")
                }
            );
            base.Configure(builder);
        }

    }
}
