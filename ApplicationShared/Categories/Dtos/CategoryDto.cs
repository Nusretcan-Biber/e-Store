using ApplicationShared.Products.Dtos;
using Core.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationShared.Categories.Dtos
{
    public class CategoryDto: BaseDto
    {
        public virtual string CategoryName { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid? ParentCategoryId { get; set; }
        public virtual List<ProductDto> ProductDtos { get; set; }
    }
}
