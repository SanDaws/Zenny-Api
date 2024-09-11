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

    // GET api/movement
    [HttpGet(Name = "GetMovements")]
    public async Task<ActionResult<IEnumerable<Movement>>> GetMovements()
    {
        return await _service.GetMovementsAsync();
    }
}
