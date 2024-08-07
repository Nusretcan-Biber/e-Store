using Core.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationShared.Categories.Dtos
{
    public class CreateCategoryDto : BaseDto
    {
        public virtual string CategoryName { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid? ParentCategoryId { get; set; } = null;
    }
}
