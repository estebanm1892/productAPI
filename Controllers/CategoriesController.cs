using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        try
        {
            var categories = await _context.Categories.Include(c => c.Products).ToListAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            // Log the exception details (for development use)
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}
