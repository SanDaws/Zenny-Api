using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Zenny_Api.Services;
using System.Linq;

namespace Zenny_Api.Controllers.Movements;

[ApiController]
[Route("api/[controller]")]
public class MovementController : ControllerBase
{
    private readonly MovementService _service;

    public MovementController(MovementService service)
    {
        _service = service;
    }

    // method to handle response and error messaging
    private ActionResult<IEnumerable<Movement>> HandleResponse(IEnumerable<Movement> movements, string notFoundMessage)
    {
        if (!movements.Any())
        {
            return NotFound(notFoundMessage);
        }
        return Ok(movements);
    }

    // get all the movements
    [HttpGet(Name = "GetMovements")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetMovements()
    {
        var movements = await _service.GetMovementsAsync();
        return HandleResponse(movements, "Movements not found");
    }

    // get all the movements whit an specific user_id
    [HttpGet("{userId}", Name = "GetMovementsByUserId")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetMovementsByUserId(int userId)
    {
        var movements = await _service.GetMovementsByUserIdAsync(userId);
        return HandleResponse(movements, "Movements not found");
    }

    // get all the movements whit an specific user_id, that transaction type is “1”
    [HttpGet("{userId}/incomes", Name = "GetIncomesByUserId")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetIncomesByUserId(int userId)
    {
        var movements = await _service.GetIncomesAsync(userId);
        return HandleResponse(movements, "Incomes not found");
    }

    // get all the movements whit an specific user_id, that transaction type is “2”
    [HttpGet("{userId}/expenses", Name = "GetExpensesByUserId")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetExpensesByUserId(int userId)
    {
        var movements = await _service.GetExpensesAsync(userId);
        return HandleResponse(movements, "Expenses not found");
    }

}
