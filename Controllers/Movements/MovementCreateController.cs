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
public class MovementCreateController : ControllerBase
{
    private readonly MovementService _service;

    public MovementCreateController(MovementService service)
    {
        _service = service;
    }

    [HttpGet("{id}", Name = "GetMovement")]
    public async Task<ActionResult<Movement>> GetMovement(uint id)
    {
        var movement = await _service.GetMovementsByUserIdAsync(id);
        if (movement == null)
        {
            return NotFound();
        }
        return Ok(movement);
    }

    [HttpPost(Name = "CreateMovement")]
    public async Task<ActionResult<Movement>> CreateMovement([FromBody] Movement movement)
    {
        if (movement == null)
        {
            return BadRequest("Movement data is required");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdMovement = await _service.CreateMovementAsync(movement);
        return CreatedAtAction(nameof(GetMovement), new { id = createdMovement.Id }, createdMovement);
    }

}
