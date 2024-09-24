using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Zenny_Api.Controllers.v2.Categories
{
    [ApiController]
    [Route("api/v2/[controller]")] // Use versioning in the route
    [ApiExplorerSettings(GroupName = "v2")]
    [Authorize] // Ensure authorization is required
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
            Description = "Returns a list of categories with their IDs and names."
        )]
        [SwaggerResponse(200, "Returns a list with all the categories.", typeof(IEnumerable<Category>))]
        [SwaggerResponse(204, "There are no categories.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        [HttpGet(Name = "AllCategoriesV2")]
        public async Task<ActionResult<IEnumerable<Category>>> AllCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            if (categories == null || categories.Count == 0)
            {
                return NoContent(); // Return 204 if no categories found
            }

            return Ok(categories); // Return 200 with the list of categories
        }
    }
}
