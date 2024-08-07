using Application.Categories;
using Application.Products;
using Application.Users;
using ApplicationShared.Categories.Services;
using ApplicationShared.Products.Services;
using ApplicationShared.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class ServiceCollector
    {
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<UserService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ProductService>();
        }
    }
}
