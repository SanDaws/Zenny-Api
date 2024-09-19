using Microsoft.EntityFrameworkCore;
using Zenny_Api.Models;

namespace Zenny_Api.Seeders;

public class MovementSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movement>().HasData(
            new Movement
            {
                Id = 1,
                MovementDate = DateTime.Parse("2024-09-18"),
                UserId = 1,
                Value = 10000,
                TransactionTypesId = 1
            },
            new Movement
            {
                Id = 2,
                MovementDate = DateTime.Parse("2024-09-19"),
                UserId = 1,
                Value = 5000,
                CategoriesId = 1,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 3,
                MovementDate = DateTime.Parse("2024-09-20"),
                UserId = 1,
                Value = 2000,
                CategoriesId = 2,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 4,
                MovementDate = DateTime.Parse("2024-09-21"),
                UserId = 2,
                Value = 15000,
                TransactionTypesId = 1
            },
            new Movement
            {
                Id = 5,
                MovementDate = DateTime.Parse("2024-09-22"),
                UserId = 2,
                Value = 7000,
                CategoriesId = 4,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 6,
                MovementDate = DateTime.Parse("2024-09-10"),
                UserId = 2,
                Value = 3000,
                CategoriesId = 5,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 7,
                MovementDate = DateTime.Parse("2024-09-15"),
                UserId = 3,
                Value = 25000,
                TransactionTypesId = 1
            },
            new Movement
            {
                Id = 8,
                MovementDate = DateTime.Parse("2024-09-16"),
                UserId = 3,
                Value = 12000,
                CategoriesId = 3,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 9,
                MovementDate = DateTime.Parse("2024-09-17"),
                UserId = 3,
                Value = 5000,
                CategoriesId = 6,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 10,
                MovementDate = DateTime.Parse("2024-09-25"),
                UserId = 3,
                Value = 20000,
                TransactionTypesId = 1
            },
            new Movement
            {
                Id = 11,
                MovementDate = DateTime.Parse("2024-09-26"),
                UserId = 3,
                Value = 10000,
                CategoriesId = 7,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 12,
                MovementDate = DateTime.Parse("2024-09-27"),
                UserId = 3,
                Value = 4000,
                CategoriesId = 8,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 13,
                MovementDate = DateTime.Parse("2024-09-11"),
                UserId = 4,
                Value = 35000,
                TransactionTypesId = 1
            },
            new Movement
            {
                Id = 14,
                MovementDate = DateTime.Parse("2024-09-12"),
                UserId = 4,
                Value = 18000,
                CategoriesId = 9,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 15,
                MovementDate = DateTime.Parse("2024-09-13"),
                UserId = 4,
                Value = 6000,
                CategoriesId = 10,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 16,
                MovementDate = DateTime.Parse("2024-08-23"),
                UserId = 4,
                Value = 22000,
                TransactionTypesId = 1
            },
            new Movement
            {
                Id = 17,
                MovementDate = DateTime.Parse("2024-08-24"),
                UserId = 4,
                Value = 15000,
                CategoriesId = 11,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 18,
                MovementDate = DateTime.Parse("2024-08-25"),
                UserId = 4,
                Value = 5000,
                CategoriesId = 12,
                TransactionTypesId = 2
            },
            new Movement
            {
                Id = 19,
                MovementDate = DateTime.Parse("2024-08-15"),
                UserId = 5,
                Value = 40000,
                TransactionTypesId = 1
            },
            new Movement
            {
                Id = 20,
                MovementDate = DateTime.Parse("2024-08-16"),
                UserId = 5,
                Value = 25000,
                CategoriesId = 13,
                TransactionTypesId = 2
            }
        );
    }
}
