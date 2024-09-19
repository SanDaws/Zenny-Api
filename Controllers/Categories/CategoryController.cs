using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;

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

    /// <summary>
    /// GET api/category
    /// </summary>
    /// <returns>
    /// all the categories
    /// </returns>
    
    [HttpGet(Name = "AllCategories")]
    public async Task<ActionResult<IEnumerable<Category>>> AllCategories()
    {
        return await _context.Categories.ToListAsync();
    }
}
