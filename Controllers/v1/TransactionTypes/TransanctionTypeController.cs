using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Swashbuckle.AspNetCore.Annotations;


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
    [SwaggerOperation(
        Summary = "Get all the transaction types",
        Description = "Returns a all the transaction type objects"
    )]
    [SwaggerResponse(200, "Returns a list with the movements of an specific user.", typeof(Movement))]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult<IEnumerable<TransactionType>>> GetTransactionTypes()
    {
        return await _context.TransactionTypes.ToListAsync();
    }
}
