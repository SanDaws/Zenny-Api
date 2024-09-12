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

    // get all the movements for the current month
    public async Task<IEnumerable<Movement>> GetMovementsAsync()
    {
        var today = DateTime.Today;
        var movements = await _context.Movements.ToListAsync();
        return movements.Where(mo => mo.MovementDate.Month == today.Month && mo.MovementDate.Year == today.Year).ToList();
    }

    // get all the movements whit an specific user_id
    public async Task<IEnumerable<Movement>> GetMovementsByUserIdAsync(int userId)
    {
        var movements = await GetMovementsAsync();
        return movements.Where(mo => mo.UserId == userId).ToList();
    }

    // get all the movements whit an specific user_id, that transaction type is “1”
    public async Task<IEnumerable<Movement>> GetIncomesAsync(int userId)
    {
        var movements = await GetMovementsByUserIdAsync(userId);
        return movements.Where(mo => mo.TransactionTypesId == 1).ToList();
    }

    // get all the movements whit an specific user_id, that transaction type is “2”
    public async Task<IEnumerable<Movement>> GetExpensesAsync(int userId)
    {
        var movements = await GetMovementsByUserIdAsync(userId);
        return movements.Where(mo => mo.TransactionTypesId == 2).ToList();
    }

    // get all the movements whit an specific user_id that transaction_type are “2” and return the calculation of all the value colum values.
    public async Task<double> GetTotalExpensesAsync(int userId)
    {
        var expenses = await GetExpensesAsync(userId);
        return expenses.Sum(mo => mo.Value);
    }

    // get all the movements whit an specific user_id that transaction_type are “1” and return the calculation of all the value colum values.
    public async Task<double> GetTotalIncomesAsync(int userId)
    {
        var incomes = await GetIncomesAsync(userId);
        return incomes.Sum(mo => mo.Value);
    }

    // get all the movements whit an specific user_id that transaction_type are “2” and got an specific id_category
    public async Task<IEnumerable<Movement>> GetExpensesByIdCategoryAsync(int userId, int idCategory)
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

    public async Task<Movement> GetMovementByIdAsync(int id)
    {
        return await _context.Movements.FindAsync(id);
    }

    // delete movement by its id
    public async Task DeleteMovementAsync(int id)
    {
        var movement = await GetMovementByIdAsync(id);
        if (movement!= null)
        {
            _context.Movements.Remove(movement);
            await _context.SaveChangesAsync();
        }
    }

}

