using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class WishlistController : ControllerBase
{
    private readonly AppDbContext _context;

    public WishlistController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/wishlist
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlist()
    {
        return await _context.Wishlists.Include(w => w.Product).ToListAsync();
    }

    // GET: api/wishlist/user/{userId}
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlistByUser(int userId)
    {
        var userWishlist = await _context.Wishlists
                                         .Where(w => w.UserId == userId)
                                         .Include(w => w.Product)
                                         .ToListAsync();

        if (!userWishlist.Any())
        {
            return NotFound("No products found in the wishlist for this user.");
        }

        return userWishlist;
    }

    // POST: api/wishlist
    [HttpPost]
    public async Task<ActionResult<Wishlist>> AddToWishlist(Wishlist wishlist)
    {
        if (wishlist == null || wishlist.ProductId <= 0 || wishlist.UserId <= 0)
        {
            return BadRequest("Invalid wishlist item.");
        }

        _context.Wishlists.Add(wishlist);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWishlist), new { id = wishlist.Id }, wishlist);
    }

    // DELETE: api/wishlist/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveFromWishlist(int id)
    {
        var wishlist = await _context.Wishlists
            .Include(w => w.Product)  // Incluye el producto asociado para devolverlo
            .FirstOrDefaultAsync(w => w.Id == id);

        if (wishlist == null)
        {
            return NotFound(new { message = "Wishlist item not found." });
        }

        _context.Wishlists.Remove(wishlist);
        await _context.SaveChangesAsync();

        // Devuelve el producto eliminado junto con un mensaje de confirmación
        return Ok(new
        {
            message = "Product removed from wishlist.",
            product = wishlist.Product
        });
    }
}
