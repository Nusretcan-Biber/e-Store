using ApplicationShared.Categories.Dtos;
using Core.BaseDtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationShared.Products.Dtos
{
    public class ProductDto : BaseDto
    {
        public virtual string ProductName { get; set; }
        public virtual string? Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }
        public virtual string? ImageURL { get; set; }
        public virtual CategoryDto Category { get; set; }  // Foreign key
    }
}
