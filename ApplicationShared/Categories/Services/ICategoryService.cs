using ApplicationShared.Categories.Dtos;
using Core.BaseServices.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationShared.Categories.Services
{
    public interface ICategoryService : IBaseCrudAppService<Category,CategoryDto,CreateCategoryDto,UpdateCategoryDto>
    {
    }
}
