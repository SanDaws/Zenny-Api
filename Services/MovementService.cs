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

    // get all the movements whit an specific user_id for the current month
    public async Task<IEnumerable<Movement>> GetMovementsByUserIdAsync(uint userId)
    {
        var today = DateTime.Today;
        var movements = await _context.Movements.ToListAsync();
        return movements.Where(mo => mo.MovementDate.Month == today.Month
                                  && mo.MovementDate.Year == today.Year
                                  && mo.UserId == userId).ToList();
    }

    // get all the movements whit an specific user_id, that transaction type is “1”
    public async Task<IEnumerable<Movement>> GetIncomesAsync(uint userId)
    {
        var movements = await GetMovementsByUserIdAsync(userId);
        return movements.Where(mo => mo.TransactionTypesId == 1).ToList();
    }

    // get all the movements whit an specific user_id, that transaction type is “2”
    public async Task<IEnumerable<Movement>> GetExpensesAsync(uint userId)
    {
        var movements = await GetMovementsByUserIdAsync(userId);
        return movements.Where(mo => mo.TransactionTypesId == 2).ToList();
    }

    // get all the movements whit an specific user_id that transaction_type are “2” and return the calculation of all the value colum values.
    public async Task<double> GetTotalExpensesAsync(uint userId)
    {
        var expenses = await GetExpensesAsync(userId);
        return expenses.Sum(mo => mo.Value);
    }

    // get all the movements whit an specific user_id that transaction_type are “1” and return the calculation of all the value colum values.
    public async Task<double> GetTotalIncomesAsync(uint userId)
    {
        var incomes = await GetIncomesAsync(userId);
        return incomes.Sum(mo => mo.Value);
    }

    // get all the movements whit an specific user_id that transaction_type are “2” and got an specific id_category
    public async Task<IEnumerable<Movement>> GetExpensesByIdCategoryAsync(uint userId, int idCategory)
    {
        var expenses = await GetExpensesAsync(userId);
        return expenses.Where(mo => mo.CategoriesId == idCategory).ToList();
    }

    // create a movement register that is a “2“, whit a value and a category, if the category value is ““ or null,  put the "9" id in it
    public async Task<Movement> CreateMovementAsync(Movement movement)
    {
        if (movement.CategoriesId <= 0)
        {
            movement.CategoriesId = 9;
        }
        _context.Movements.Add(movement);
        await _context.SaveChangesAsync();
        return movement;
    }

    public async Task<Movement> GetMovementByIdAsync(uint id)
    {
        return await _context.Movements.FindAsync(id);
    }

    // delete movement by its id
    public async Task DeleteMovementAsync(uint id)
    {
        var movement = await GetMovementByIdAsync(id);
        if (movement != null)
        {
            _context.Movements.Remove(movement);
            await _context.SaveChangesAsync();
        }
    }

    // delete all movements from an user_id
    public async Task DeleteMovementsByUserIdAsync(uint userId)
    {
        var movements = await GetMovementsByUserIdAsync(userId);
        _context.Movements.RemoveRange(movements);
        await _context.SaveChangesAsync();
    }

    internal object Entry(Movement movement)
    {
        throw new NotImplementedException();
    }

    // update a movement by the id movement
    public async Task UpdateMovementAsync(Movement movement)
    {
        var existingMovement = await _context.Movements.FindAsync(movement.Id);
        if (existingMovement == null)
        {
            throw new KeyNotFoundException("Movement not found");
        }

        // Update the movement
        existingMovement.MovementDate = movement.MovementDate;
        existingMovement.UserId = movement.UserId;
        existingMovement.Value = movement.Value;
        existingMovement.CategoriesId = movement.CategoriesId;
        existingMovement.TransactionTypesId = movement.TransactionTypesId;

        _context.Movements.Update(existingMovement);
        await _context.SaveChangesAsync();
    }

}

