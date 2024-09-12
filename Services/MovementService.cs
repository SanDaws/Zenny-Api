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

     public async Task<IEnumerable<Movement>> GetMovementsAsync()
    {
        return await _context.Movements.ToListAsync();
    }


      public async Task<IEnumerable<Movement>> GetMovementsByUserIdAsync(int userId)
    {
        var movements = await _context.Movements.ToListAsync();
        return movements.Where(mo => mo.UserId == userId).ToList();
    }




}
