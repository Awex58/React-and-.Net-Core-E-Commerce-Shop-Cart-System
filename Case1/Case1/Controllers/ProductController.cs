using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Dtos;
using Case1.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Case1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;

        }


        [HttpGet("productall")]
        //   [Authorize(Roles = "Admin")] Authorize olsaydı
        public IActionResult ProductAll()
        {

            var productallcheck = _ProductService.GetAllProduct();
            if (!productallcheck.Success)
            {
                return BadRequest(productallcheck.Message);
            }
            else
            {
                return Ok(productallcheck.Data);
            }


        }

        [HttpPost("productid")]
        public IActionResult Productid([FromBody] ProductDto pdto) 
        {
           
            var productidcheck = _ProductService.GetProduct(pdto.id);

            if (!productidcheck.Success)
            {
                return BadRequest(productidcheck.Message);
            }
            else
            {
                return Ok(productidcheck.Data);
            }


        }


    }
}
