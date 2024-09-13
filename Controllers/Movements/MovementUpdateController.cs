using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Models;
using Zenny_Api.Services;

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
                return NotFound("Movement not found");
            }
            await _service.UpdateMovementAsync(movement);
            return Ok("Movement updated successfully");
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
