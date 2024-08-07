using ApplicationShared.Products.Dtos;
using Core.BaseServices.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationShared.Products.Services
{
    public interface IProductService : IBaseCrudAppService<Product,ProductDto,CreateProductDto,UpdateProductDto>
    {
    }
}
