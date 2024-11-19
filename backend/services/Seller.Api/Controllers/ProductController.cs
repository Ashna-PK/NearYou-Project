using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seller.Api.Data;
using Seller.Api.Models;
using Seller.Api.Repository.IRepository;

namespace Seller.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _context;

        public ProductController(IProductRepository  context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Getshops()
        {
            var result = await _context.getProducts();
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("shop")]
        public async Task<ActionResult<IEnumerable<Product>>> GetshopsByShop(int shopId)
        {
            var result = await _context.getProductsByShop(shopId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetShop(int id)
        {
            var product = await _context.getProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product; 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto product)
        {

            var result = await _context.editProduct(id, product);
            if (result == null)
            {
                return BadRequest();
            }

            //_context.Entry(userClass).State = EntityState.Modified;
            //return Ok();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(int sellerId, ProductDto product)
        {
            var result = await _context.addProductDetails(sellerId, product);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _context.deleteProduct(id);
            if (!result)/// result==null (dont do)
                return NotFound("product not found.");
            return Ok(result);
        }
        [HttpPut("{productId}/{quantity}")]
        public async Task<IActionResult> UpdateQuantity(int productId, int quantity) //[FromBody]
        {

            var product=await _context.updateQuantity(productId,quantity);
            return Ok(product); // Optionally return the updated product
        }
    }

}
