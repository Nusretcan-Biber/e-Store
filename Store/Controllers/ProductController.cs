using Application.Categories;
using Application.Products;
using Application.Users;
using ApplicationShared.Categories.Dtos;
using ApplicationShared.Products.Dtos;
using ApplicationShared.Products.Services;
using ApplicationShared.Users.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private ProductService productService;

        public ProductController(IProductService _productService, ProductService productService)
        {
            this._productService = _productService;
            this.productService = productService;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var result = productService.GetAll();
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpGet(nameof(Get))]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get(Guid guid)
        {
            var result = await productService.Get(guid);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpDelete(nameof(DeleteProduct))]
        public async Task<ActionResult<IEnumerable<ProductDto>>> DeleteProduct(Guid guid)
        {
            var result = await _productService.DeleteAsync(guid);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpPost(nameof(InsertProduct))]
        public async Task<ActionResult> InsertProduct(CreateProductDto createProductDto)
        {
            try
            {
                var result = await productService.InsertAsync(createProductDto);

                if (result > 0)
                {
                    // Ekleme başarılı oldu, uygun bir yanıt döndür
                    return Ok(new { Message = "User created successfully", UserId = result });
                }
                else
                {
                    // Ekleme başarısız oldu, uygun bir hata yanıtı döndür
                    return StatusCode(500, "An error occurred while creating the user");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda genel bir hata yanıtı döndür
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }

        [HttpPut(nameof(UpdateProduct))]
        public async Task<ActionResult<IEnumerable<ProductDto>>> UpdateProduct(Guid guid, CreateProductDto productDto)
        {
            productDto.Guid = guid;
            var result = await productService.UpdateAsync(productDto);
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

    }
}
