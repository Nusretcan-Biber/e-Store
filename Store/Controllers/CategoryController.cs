using Application.Categories;
using Application.Users;
using ApplicationShared.Categories.Dtos;
using ApplicationShared.Categories.Services;
using ApplicationShared.Services.Users;
using ApplicationShared.Users.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private CategoryService categoryService;

        public CategoryController(ICategoryService _categoryService, CategoryService categoryService)
        {
            this._categoryService = _categoryService;
            this.categoryService = categoryService;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var result = categoryService.GetAll();
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }


        [HttpGet(nameof(Get))]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get(Guid guid)
        {
            var result = await categoryService.Get(guid);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpDelete(nameof(DeleteCategory))]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> DeleteCategory(Guid guid)
        {
            var result = await _categoryService.DeleteAsync(guid);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpPost(nameof(InsertCategory))]
        public async Task<ActionResult> InsertCategory(CreateCategoryDto createCategoryDto)
        {
            try
            {
                var result = await categoryService.InsertAsync(createCategoryDto);

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

        [HttpPut(nameof(UpdateCategory))]
        public async Task<ActionResult<IEnumerable<UserDto>>> UpdateCategory(Guid guid, CreateCategoryDto categoryDto)
        {
            categoryDto.Guid = guid;
            var result = await categoryService.UpdateAsync(categoryDto);
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

    }
}
