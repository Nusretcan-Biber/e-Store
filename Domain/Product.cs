using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string? Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }
        public virtual string? ImageURL { get; set; }
        public virtual int CategoryId { get; set; }  // Foreign key
        public virtual Category Category { get; set; }

    }
}
