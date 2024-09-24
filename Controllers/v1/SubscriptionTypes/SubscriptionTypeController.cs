using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Zenny_Api.Controllers.v1.SubscriptionTypes;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
public class SubscriptionTypeController : ControllerBase
{
    private readonly ILogger<SubscriptionTypeController> _logger;
    private readonly UserDbContext _context;

    public SubscriptionTypeController(ILogger<SubscriptionTypeController> logger, UserDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET api/SubscriptionType
    [HttpGet(Name = "GetSubscriptionType")]
    [SwaggerOperation(
    Summary = "Get all suscription types",
    Description = "Get all suscription types exiting"
    )]
    [SwaggerResponse(200, "subscriptions successfully found", typeof(User))]
    [SwaggerResponse(404, "Suscription types not found.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult<IEnumerable<SubscriptionType>>> GetSubscriptionTypes()
    {
        var suscriptionType = await _context.SubscriptionTypes.ToListAsync();
        if (suscriptionType == null)
        {
            return NotFound("Tipos de suscripciones no encontradas.");
        }
        return suscriptionType;
    }
}
