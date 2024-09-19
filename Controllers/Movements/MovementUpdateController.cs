using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Models;
using Zenny_Api.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Zenny_Api.Controllers.Movements;

[ApiController]
[Route("api/[controller]")]
public class MovementUpdateController : ControllerBase
{
    private readonly MovementService _service;

    public MovementUpdateController(MovementService service)
    {
        _service = service;
    }

    // update a movement by the id movement
    [HttpPut("{id}", Name = "UpdateMovement")]
     [SwaggerOperation(
        Summary = "Update a movement",
        Description = "Update a movement by the id movement"
    )]
    [SwaggerResponse(200, "Movement successfully updated", typeof(Movement))]
    [SwaggerResponse(204, "Movement not found.")]
    [SwaggerResponse(400, "Movement data is required or invalid.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<ActionResult> UpdateMovement(uint id, Movement movement)
    {
        if (id != movement.Id)
        {
            return BadRequest("IDs do not match");
        }
        try
        {
            var existingMovement = await _service.GetMovementByIdAsync(id);
            if (existingMovement == null)
            {
                return NoContent();
            }
            await _service.UpdateMovementAsync(movement);
            return Ok(movement);
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}
