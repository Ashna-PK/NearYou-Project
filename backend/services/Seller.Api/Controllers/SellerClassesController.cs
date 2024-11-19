using Microsoft.AspNetCore.Mvc;

namespace Seller.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerClassesController : ControllerBase
    {
        //    private readonly ISellerRepository _context;

        //    public SellerClassesController(ISellerRepository context)
        //    {
        //        _context = context;
        //    }

        //    // GET: api/SellerClasses
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<SellerClass>>> Getsellers()
        //    {
        //        var result = await _context.getSellers();
        //        if (result == null)
        //            return NotFound();
        //        return Ok(result);
        //    }

        //    // GET: api/SellerClasses/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<SellerClass>> GetSellerClass(int id)
        //    {
        //        var seller = await _context.getSellerById(id);

        //        if (seller == null)
        //        {
        //            return NotFound();
        //        }

        //        return seller; ;
        //    }

        //    // PUT: api/SellerClasses/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutSellerClass(int id, SellerDto sellerClass)
        //    {

        //        var result = await _context.editProfile(id, sellerClass);
        //        if (result == null)
        //        {
        //            return BadRequest();
        //        }

        //        //_context.Entry(userClass).State = EntityState.Modified;
        //        //return Ok();
        //        return Ok(result);
        //    }
        //    [HttpPut]
        //    public async Task<IActionResult> PutSeller(int id,bool isVerified,int rating)
        //    {
        //        var seller = await _context.getSellerById(id);

        //        seller.IsVerified =isVerified;
        //        if (seller == null)
        //        {
        //            return BadRequest();
        //        }

        //        //_context.Entry(userClass).State = EntityState.Modified;
        //        //return Ok();
        //        return Ok(seller);
        //    }
        //    // POST: api/SellerClasses
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<SellerClass>> PostSellerClass(SellerDto sellerClass)
        //    {
        //        var result = await _context.createSeller(sellerClass);

        //        return Ok(result);
        //    }

        //    // DELETE: api/SellerClasses/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteSellerClass(int id)
        //    {
        //        var result = await _context.deleteSeller(id);
        //        if (!result)/// result==null (dont do)
        //            return NotFound("seller not found.");
        //        return Ok(result);
        //    }
    }
}
