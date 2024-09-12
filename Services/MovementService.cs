using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zenny_Api.Models;

namespace Zenny_Api.Services;

public class MovementService
{
    private readonly MovementDbContext _context;

    public MovementService(MovementDbContext context)
    {
        _context = context;
    }

    // get all the movements
    public async Task<IEnumerable<Movement>> GetMovementsAsync()
    {
        return await _context.Movements.ToListAsync();
    }

    // get all the movements whit an specific user_id
    public async Task<IEnumerable<Movement>> GetMovementsByUserIdAsync(int userId)
    {
        var movements = await GetMovementsAsync(); // Reutilización del método
        return movements.Where(mo => mo.UserId == userId).ToList();
    }
}

