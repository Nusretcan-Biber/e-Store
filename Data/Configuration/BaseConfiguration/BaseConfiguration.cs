using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration.BaseConfiguration
{
    public class BaseConfiguration<TModel> : IEntityTypeConfiguration<TModel> where TModel : BaseEntity,IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.HasKey(x => x.Guid);
        }
    }
}
