using Case1.Core.Entities.Dtos;
using Case1.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Case1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesProductsController:ControllerBase
    {

        private ISalesProductsService _salesprorductservices;

        public SalesProductsController(ISalesProductsService salesprorductservices)
        {
            _salesprorductservices = salesprorductservices;

        }

        [HttpGet("salesall")]
        public IActionResult SalesAll()
        {

            var salesallcheck = _salesprorductservices.GetAllSalesProducts();
            if (!salesallcheck.Success)
            {
                return BadRequest(salesallcheck.Message);
            }
            else
            {
                return Ok(salesallcheck.Data);
            }


        }



        [HttpPost("salesadd")]
        public IActionResult SalesAdd([FromBody] SaledDto saled)
        {

            var SalesAddcheck = _salesprorductservices.Add(saled);
            if (!SalesAddcheck.Success)
            {
                return BadRequest(SalesAddcheck.Message);
            }
            else
            {
                return Ok();
            }


        }






    }
}
