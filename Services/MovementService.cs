using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Zenny_Api.Models;

namespace Zenny_Api.Services;

public class MovementService
{
    private readonly MovementDbContext _context;

    public MovementService(MovementDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Movement>>> GetMovementsAsync()
    {
        return await _context.Movements.ToListAsync();
    }
}
