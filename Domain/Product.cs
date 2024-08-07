using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : BaseEntity
    {
     //   public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string? Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }
        public virtual string? ImageURL { get; set; }
        public virtual Guid CategoryId { get; set; }  // Foreign key
        public virtual Category Category { get; set; }

        public Product()
        {
            
        }
        public Product(string productName,
                       string? description,
                       decimal price,
                       int stock,
                       string? ımageURL,
                       Guid categoryId)
        {
            
            ProductName = productName;
            Description = description;
            Price = price;
            Stock = stock;
            ImageURL = ımageURL;
            CategoryId = categoryId;
        }

    }
}
