using ApplicationShared.Categories.Dtos;
using ApplicationShared.Categories.Services;
using ApplicationShared.Mapper;
using ApplicationShared.Products.Dtos;
using Core.BaseServices.Services;
using Data.Context;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories
{
    public class CategoryService : BaseCrudAppService<PostgreDbContext, Category,CategoryDto,CreateCategoryDto,UpdateCategoryDto>, ICategoryService
    {
        public virtual async Task<int> InsertAsync(CreateCategoryDto createCategoryDto)
        {
            var createCategory = MappingProfile<CreateCategoryDto, Category>.Instance.Mapper.Map<Category>(createCategoryDto);
            return await base.InsertAsync(createCategory);
        }

        public virtual List<CategoryDto> GetAll()
        {
            //return base.GetAll()
            //           .Include(c => c.ParentCategory)
            //           .Include(c => c.SubCategories)
            //           .Include(c => c.Products);

            List<CategoryDto> categoryDtos = new List<CategoryDto>();

           var categories = base.GetAll()
                       .Include(c => c.ParentCategory)
                       .Include(c => c.SubCategories)
                       .Include(c => c.Products);

            foreach (var category in categories)
            {
                categoryDtos.Add(new CategoryDto()
                {
                    ProductDtos = (from x in category.Products
                                  select new ProductDto()
                                  {
                                      ProductName = x.ProductName,
                                      Description = x.Description,
                                      Guid = x.Guid,
                                  }).ToList(),
                    Guid = category.Guid,
                    CategoryName= category.CategoryName,
                    Description= category.Description,
                    ParentCategoryId = category.ParentCategoryId
                    
                });
            }
            return categoryDtos;




        }

        public virtual async Task<CategoryDto> Get(Guid guid)
        {
            var category = await base.GetAll()
                             .Include(c => c.ParentCategory)
                             .Include(c => c.SubCategories)
                             .Include(c => c.Products)
                             .FirstOrDefaultAsync(c => c.Guid == guid);

            var categoryDto = new CategoryDto 
            {
                Guid = category.Guid,
                CategoryName = category.CategoryName,
                Description = category.Description,
                ParentCategoryId = category.ParentCategoryId,
                ProductDtos = category.Products.Select(p=>new ProductDto
                {
                    Guid=p.Guid,
                    ProductName=p.ProductName,
                    Description=p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    ImageURL=p.ImageURL,
                    Category = new CategoryDto { Guid = p.Category.Guid, CategoryName = p.Category.CategoryName}
                }).ToList()
            };

            return categoryDto;
        }

        public virtual async Task<int> UpdateAsync(CreateCategoryDto updateCategoryDto)
        {
            var updateCategory = MappingProfile<CreateCategoryDto, Category>.Instance.Mapper.Map<Category>(updateCategoryDto);
            updateCategory.UpdatedDate = DateTime.UtcNow;
            updateCategory.IsUpdated = true;

            return await base.UpdateAsync(updateCategory);
        }
    }
}
