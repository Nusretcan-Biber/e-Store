using Application.Mappers;
using ApplicationShared.Categories.Dtos;
using ApplicationShared.Mapper;
using ApplicationShared.Products.Dtos;
using ApplicationShared.Products.Services;
using ApplicationShared.Users.Dtos;
using Core.BaseServices.Services;
using Data.Context;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products
{
    public class ProductService : BaseCrudAppService<PostgreDbContext, Product, ProductDto, CreateProductDto, UpdateProductDto>, IProductService
    {
        public virtual async Task<int> InsertAsync(CreateProductDto createProductDto)
        {
            var createProduct = MappingProfile<CreateProductDto, Product>.Instance.Mapper.Map<Product>(createProductDto);
            return await base.InsertAsync(createProduct);
        }
        public virtual List<ProductDto> GetAll()
        {
            //   var productss = base.GetAll().Include(p => p.Category);



            //    ProductMappingProfile productMappingProfile = new ProductMappingProfile();
            //    var result= productMappingProfile.Mapper.Map<List<ProductDto>>(productss);

            //  //  var result = MappingProfile<List<Product>, List<ProductDto>>.Instance.Mapper.Map<List<ProductDto>>(base.GetAll().Include(p => p.Category));



            //    return result.ToList() ;


            List<ProductDto> productDtos = new List<ProductDto>();

            var productList = base.GetAll().Include(p => p.Category);

            foreach (var item in productList)
            {
                productDtos.Add(new ProductDto()
                {
                    Category = new CategoryDto()
                    {
                        CategoryName = item.Category.CategoryName,
                        Description = item.Category.Description,
                        Guid = item.Category.Guid,
                        ParentCategoryId = item.Category.ParentCategoryId
                    },
                    Description = item.Description,
                    Guid = item.Guid,
                    ImageURL = item.ImageURL,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Stock = item.Stock



                });
            }
            return productDtos;

        }

        public virtual async Task<ProductDto> Get(Guid guid)
        {
            var product = await base.GetAll().Include(p => p.Category).FirstOrDefaultAsync(p => p.Guid == guid);

            var productDto = new ProductDto
            {
                Guid= product.Guid,
                ProductName= product.ProductName,
                Description= product.Description,
                ImageURL= product.ImageURL,
                Price= product.Price,
                Stock= product.Stock,
                Category = new CategoryDto
                {
                    Guid = product.Category.Guid,
                    CategoryName = product.Category.CategoryName,
                    Description = product.Category.Description,
                    ParentCategoryId= product.Category.ParentCategoryId
                }
            };

            return productDto;
        }


        public virtual async Task<int> UpdateAsync(CreateProductDto uptadeProductDto)
        {
            var updateProduct = MappingProfile<CreateProductDto, Product>.Instance.Mapper.Map<Product>(uptadeProductDto);
            updateProduct.UpdatedDate = DateTime.UtcNow;
            updateProduct.IsUpdated = true;

            return await base.UpdateAsync(updateProduct);
        }
    }
}
