using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zenny_Api.Models;
using Zenny_Api.Services;

namespace Zenny_Api.Controllers.Movements;

[ApiController]
[Route("api/[controller]")]
public class MovementDeleteController : ControllerBase
{
    private readonly MovementService _service;

    public MovementDeleteController(MovementService service)
    {
        _service = service;
    }

    // delete movement by its id
    [HttpDelete("{id}", Name = "DeleteMovement")]
    public async Task<ActionResult> DeleteMovement(int id)
    {
        var movement = await _service.GetMovementByIdAsync(id);
        if (movement == null)
        {
            return NotFound("Movement not found");
        }
        await _service.DeleteMovementAsync(id);
        return Ok(movement);
    }

}
