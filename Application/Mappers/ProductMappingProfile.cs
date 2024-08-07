using ApplicationShared.Categories.Dtos;
using ApplicationShared.Mapper;
using ApplicationShared.Products.Dtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class ProductMappingProfile : MappingProfile<Product, ProductDto>
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(x=>x.Category,y=>y.MapFrom(z=>z.Category));
            CreateMap<Category, CategoryDto>();

        }
    }
}
