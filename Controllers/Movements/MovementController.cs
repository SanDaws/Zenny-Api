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
    private ActionResult<T> HandleResponse<T>(T result, string notFoundMessage)
    {
        if (result == null || (result is IEnumerable<Movement> movements && !movements.Any()))
        {
            return NotFound(notFoundMessage);
        }
        // for simple values like double, we do not use the notFoundMessage
        if (result is double value && value == 0)
        {
            return NotFound(notFoundMessage);
        }
        return Ok(result);
   
    // get all the movements whit an specific user_id for the current month

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

    // get all the movements whit an specific user_id that transaction_type are “2” and return the calculation of all the value colum values.
    [HttpGet("{userId}/total-expenses", Name = "GetTotalExpensesById")]
    public async Task<ActionResult<double>> GetTotalExpensesById(int userId)
    {
        var totalExpenses = await _service.GetTotalExpensesAsync(userId);
        // handle the response with a total value
        if (totalExpenses == 0)
        {
            return NotFound("No expenses found for the user");
        }
        return Ok(totalExpenses);
    }

    // get all the movements whit an specific user_id that transaction_type are “1” and return the calculation of all the value colum values.
    [HttpGet("{userId}/total-incomes", Name = "GetTotalIncomesById")]
    public async Task<ActionResult<double>> GetTotalIncomesById(int userId)
    {
        var totalIncomes = await _service.GetTotalIncomesAsync(userId);
        // handle the response with a total value
        if (totalIncomes == 0)
        {
            return NotFound("No incomes found for the user");
        }
        return Ok(totalIncomes);
    }

    // get all the movements whit an specific user_id that transaction_type are “2” and got an specific id_category
    [HttpGet("{userId}/expenses/{categoryId}", Name = "GetExpensesByIdAndCategoryId")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetExpensesByIdAndCategoryId(int userId, int categoryId)
    {
        var movements = await _service.GetExpensesByIdCategoryAsync(userId, categoryId);
        return HandleResponse(movements, "Expenses not found for the given category");
    }

}
