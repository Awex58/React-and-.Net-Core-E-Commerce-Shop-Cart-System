using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Dtos;
using Case1.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Case1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController:ControllerBase
    {
        private ICartService _CartService;

        public CartController(ICartService cartService)
        {
            _CartService = cartService;

        }


        [HttpPost("cartadd")]
        public IActionResult Cartadd([FromBody] CartDto cartdto )
        {

            var Cartcheck = _CartService.AddCart(cartdto);
            if (!Cartcheck.Success)
            {
                return BadRequest(Cartcheck.Message);
            }
            else
            {
                return Ok(); // varsa 
            }


        }

        [HttpPost("cartuser")] //usere özel cartları cağırır
        public IActionResult CartUser([FromBody] CartDto cartdto)
        {

            var Cartcheck = _CartService.GetUserCart(cartdto.UserId);
            if (!Cartcheck.Success)
            {
                return BadRequest(Cartcheck.Message);
            }
            else
            {
                return Ok(Cartcheck.Data); 
            }


        }
        [HttpPost("cartdelete")] // gelen cart id'yi temizler
        public IActionResult CartDelete([FromBody] Cart cart)
        {

            var Cartcheck = _CartService.Delete(cart);
            if (!Cartcheck.Success)
            {
                return BadRequest(Cartcheck.Message);
            }
            else
            {
                return Ok();
            }


        }

    }
}
