using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zenny_Api.Models;
using Zenny_Api.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Zenny_Api.Controllers.Movements;

[ApiController]
[Route("api/delete")]
public class MovementDeleteController : ControllerBase
{
    private readonly MovementService _service;

    public MovementDeleteController(MovementService service)
    {
        _service = service;
    }

    // delete movement by its id
    [HttpDelete("{id}", Name = "DeleteMovement")]
    [SwaggerOperation(
        Summary = "Delete a movement",
        Description = "Delete a movement by its id"
    )]
    [SwaggerResponse(200, "Movement successfully deleted", typeof(Movement))]
    [SwaggerResponse(204, "Movement not found.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult> DeleteMovement(uint id)
    {
        var movement = await _service.GetMovementByIdAsync(id);
        if (movement == null)
        {
            return NoContent();
        }
        await _service.DeleteMovementAsync(id);
        return Ok(movement);
    }

    // delete all movements from an user_id
    [HttpDelete("deleteAllMovements/{id}", Name = "DeleteMovementsByUserId")]
    [SwaggerOperation(
        Summary = "Delete all movements",
        Description = "Delete all movements from an user_id"
    )]
    [SwaggerResponse(200, "Movements successfully deleted.", typeof(string))]
    [SwaggerResponse(204, "No movements found for the user.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult> DeleteMovementsByUserId(uint id)
    {
        await _service.DeleteMovementsByUserIdAsync(id);
        return Ok("Movements deleted");
    }
}
