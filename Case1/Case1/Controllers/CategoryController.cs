using Case1.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Case1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController:ControllerBase
    {

        private ICategoryService _CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;

        }



        [HttpGet("categoryall")]
        public IActionResult CategoryAll()
        {

            var CategoryAllcheck = _CategoryService.GetAllCategories();
            if (!CategoryAllcheck.Success)
            {
                return BadRequest(CategoryAllcheck.Message);
            }
            else
            {
                return Ok(CategoryAllcheck.Data);
            }


        }
    }
}
