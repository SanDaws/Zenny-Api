using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Zenny_Api.Services;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace Zenny_Api.Controllers.Movements;

[ApiController]
[Route("api/v1/movement")]
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

        if (result is double value && value == 0)
        {
            return NotFound(notFoundMessage);
        }
        return Ok(result);
    }

    // get all the movements whit an specific user_id for the current month
    [HttpGet("{id}", Name = "GetMovementsByUserId")]
    [SwaggerOperation(
        Summary = "Get all the movements with an specific user_id",
        Description = "Returns all the movements with an specific user_id for the current month"
    )]
    [SwaggerResponse(200, "Returns a list with the movements of an specific user.", typeof(IEnumerable<Movement>))]
    [SwaggerResponse(204, "There are no registered movements.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetMovementsByUserId(uint id)
    {
        var movements = await _service.GetMovementsByUserIdAsync(id);
        return HandleResponse(movements, "Movements not found");
    }

    // get all the movements whit an specific user_id, that transaction type is “1”
    [HttpGet("getIncomes/{id}", Name = "GetIncomesByUserId")]
    [SwaggerOperation(
        Summary = "Get all the incomes with an specific user_id",
        Description = "Returns all the incomes with an specific user_id for the current month"
    )]
    [SwaggerResponse(200, "Returns a list with the incomes of an specific user.", typeof(IEnumerable<Movement>))]
    [SwaggerResponse(204, "There are no registered incomes.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetIncomesByUserId(uint id)
    {
        var movements = await _service.GetIncomesAsync(id);
        return HandleResponse(movements, "Incomes not found");
    }

    // get all the movements whit an specific user_id, that transaction type is “2”
    [HttpGet("getExpenses/{id}", Name = "GetExpensesByUserId")]
    [SwaggerOperation(
        Summary = "Get all the expenses with an specific user_id",
        Description = "Returns all the expenses with an specific user_id for the current month"
    )]
    [SwaggerResponse(200, "Returns a list with the expenses of an specific user.", typeof(IEnumerable<Movement>))]
    [SwaggerResponse(204, "There are no registered expenses.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetExpensesByUserId(uint id)
    {
        var movements = await _service.GetExpensesAsync(id);
        return HandleResponse(movements, "Expenses not found");
    }

    // get all the movements whit an specific user_id that transaction_type are “2” and return the calculation of all the value colum values.
    [HttpGet("getTotalExpenses/{id}", Name = "GetTotalExpensesById")]
    [SwaggerOperation(
        Summary = "Get the total expenses of an specific user",
        Description = "Returns the total expenses of an specific user for the current month"
    )]
    [SwaggerResponse(200, "Returns the total expenses of an specific user.", typeof(double))]
    [SwaggerResponse(404, "No expenses found for the user.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult<double>> GetTotalExpensesById(uint id)
    {
        var totalExpenses = await _service.GetTotalExpensesAsync(id);
        // handle the response with a total value
        if (totalExpenses == 0)
        {
            return NotFound("No expenses found for the user");
        }
        return Ok(totalExpenses);
    }

    // get all the movements whit an specific user_id that transaction_type are “1” and return the calculation of all the value colum values.
    [HttpGet("getTotalIncomes/{id}", Name = "GetTotalIncomesById")]
    [SwaggerOperation(
        Summary = "Get the total incomes of an specific user",
        Description = "Returns the total incomes of an specific user for the current month"
    )]
    [SwaggerResponse(200, "Returns the total incomes of an specific user.", typeof(double))]
    [SwaggerResponse(404, "No incomes found for the user.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult<double>> GetTotalIncomesById(uint id)
    {
        var totalIncomes = await _service.GetTotalIncomesAsync(id);
        // handle the response with a total value
        if (totalIncomes == 0)
        {
            return NotFound("No incomes found for the user");
        }
        return Ok(totalIncomes);
    }

    // get all the movements whit an specific user_id that transaction_type are “2” and got an specific id_category
    [HttpGet("expenses/{id}/{categoryId}", Name = "GetExpensesByIdAndCategoryId")]
    [SwaggerOperation(
        Summary = "Get all the expenses with an specific user_id and category_id",
        Description = "Returns all the expenses with an specific user_id and a specific category_id for the current month"
    )]
    [SwaggerResponse(200, "Returns a list with the expenses of an specific user and category.", typeof(IEnumerable<Movement>))]
    [SwaggerResponse(404, "No expenses found for the given category for the user.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetExpensesByIdAndCategoryId(uint id, int categoryId)
    {
        var movements = await _service.GetExpensesByIdCategoryAsync(id, categoryId);
        return HandleResponse(movements, "Expenses not found for the given category");
    }

}

