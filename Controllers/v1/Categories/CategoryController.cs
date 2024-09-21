using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Zenny_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly MovementDbContext _context;

    public CategoryController(ILogger<CategoryController> logger, MovementDbContext context)
    {
        _logger = logger;
        _context = context;
    }

   [SwaggerOperation(
        Summary = "Get all categories",
        Description = "return a list of categories whit their id and name "
    )]
    [SwaggerResponse(200, "Returns a list with all the categories.", typeof(Category))]
    [SwaggerResponse(204, "There are no categories.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    
    [HttpGet(Name = "AllCategories")]
    public async Task<ActionResult<IEnumerable<Category>>> AllCategories()
    {
        return await _context.Categories.ToListAsync();
    }
}
