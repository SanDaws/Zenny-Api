using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;

namespace Zenny_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<ActionResult<IEnumerable<SubscriptionType>>> GetSubscriptionTypes()
    {
        return await _context.SubscriptionTypes.ToListAsync();
    }
}
