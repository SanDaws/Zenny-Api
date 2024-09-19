using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;


namespace Zenny_Api.Controllers.TransactionTypes;

[ApiController]
[Route("api/[controller]")]
public class TransanctionTypeController : ControllerBase
{
    private readonly ILogger<TransanctionTypeController> _logger;
    private readonly MovementDbContext _context;

    public TransanctionTypeController(ILogger<TransanctionTypeController> logger, MovementDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET api/transactionType
    [HttpGet(Name = "GetTransactionTypes")]
    public async Task<ActionResult<IEnumerable<TransactionType>>> GetTransactionTypes()
    {
        return await _context.TransactionTypes.ToListAsync();
    }
}
