using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zenny_Api.Models;
using Zenny_Api.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Zenny_Api.Controllers.v2.Movements;

[ApiController]
[Route("api/v2/createMovement")]
[ApiExplorerSettings(GroupName = "v2")]

public class MovementCreateController : ControllerBase
{
    private readonly MovementService _service;

    public MovementCreateController(MovementService service)
    {
        _service = service;
    }

    [HttpPost(Name = "CreateMovementV2")]
    [SwaggerOperation(
        Summary = "Create a movement",
        Description = "Create a movement based on the specified parameters"
    )]
    [SwaggerResponse(200, "Movement successfully created", typeof(Movement))]
    [SwaggerResponse(400, "Movement data is required or invalid.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
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
        return Ok(createdMovement);
    }
}
