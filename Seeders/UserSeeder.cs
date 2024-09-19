using Microsoft.EntityFrameworkCore;
using Zenny_Api.Models;

namespace Zenny_Api.Seeders
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "John",
                    LastName = "Doe",
                    Email = "john.doe@gmail.com",
                    Password = "AQAAAAIAAYagAAAAEMdFhcD1F5/AEIUpec2VvWSdPRIoL1XQhv3ZUD1vLeOPjH5Hd9ttkWii7vYBDbIAOg==", //123
                    SubscriptionTypesId = 1
                },
                new User
                {
                    Id = 2,
                    Name = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@gmail.com",
                    Password = "AQAAAAIAAYagAAAAEOL51N9ITma/uetBXtmwTKwB1jYW2gh1Lu+7IoUn10LDiZLjLeP9cmYD9mX4X6l//A==", // 456
                    SubscriptionTypesId = 1
                },
                 new User
                 {
                     Id = 3,
                     Name = "John",
                     LastName = "gency",
                     Email = "Jhonh@gmail.com",
                     Password = "AQAAAAIAAYagAAAAEMy9Y8UXBvAToeGTkAESFaQ/+BOQyfh9PvKUtcLY5F3ux0UwzxIJguH/yCJMdPgs5Q==", // contraseña
                     SubscriptionTypesId = 1
                 },
                new User
                {
                    Id = 4,
                    Name = "David",
                    LastName = "Williams",
                    Email = "david.williams@gmail.com",
                    Password = "AQAAAAIAAYagAAAAEMwLpIDa/KH8lpkhv+GoRPyUanbnKOVkWTqFCyOEtgRRFDDlXIm5wAjbxEjpSArWtA==", // david12
                    SubscriptionTypesId = 1
                },
                new User
                {
                    Id = 5,
                    Name = "Sophia",
                    LastName = "Davis",
                    Email = "sophia.davis@gmail.com",
                    Password = "AQAAAAIAAYagAAAAECA8MhaHudUaw8vPoZzVNieeQ5+IL4WxitfJKupeZcEo5ETbvyilMLw/wSdIXaKBkg==", // micontraseña
                    SubscriptionTypesId = 2
                },
                new User
                {
                    Id = 6,
                    Name = "James",
                    LastName = "Miller",
                    Email = "james.miller@hotmail.com",
                    Password = "AQAAAAIAAYagAAAAEIEN9uyCQUtm/qaVh/TFA/K2debhdvlNMKkWtgM3lQROQZyap9u/KqKcH+yUqhZE+w==", // hashed
                    SubscriptionTypesId = 1
                },
                new User
                {
                    Id = 7,
                    Name = "Isabella",
                    LastName = "Garcia",
                    Email = "isabella.garcia@hotmail.com",
                    Password = "AQAAAAIAAYagAAAAEO0qlrHwwg3pDj6pCoIrxgqX0kORKx8Bfzsdsi6/QRXOb9HrvtGz/TZ/6UpRi4cOig==", // hashed
                    SubscriptionTypesId = 1
                },
                new User
                {
                    Id = 8,
                    Name = "Emma",
                    LastName = "Rodriguez",
                    Email = "emma.rodriguez@hotmail.com",
                    Password = "AQAAAAIAAYagAAAAEO0qlrHwwg3pDj6pCoIrxgqX0kORKx8Bfzsdsi6/QRXOb9HrvtGz/TZ/6UpRi4cOig==", // hashed
                    SubscriptionTypesId = 2
                },
                new User
                {
                    Id = 9,
                    Name = "Olivia",
                    LastName = "Wilson",
                    Email = "olivia.wilson@hotmail.com",
                    Password = "AQAAAAIAAYagAAAAENNiUrRyyMsKBHWjGJkxcaggGlz/w55oHx+JeoBE91Vq8ufWIElWX3S0cz9gfbPT4A==", // patu
                    SubscriptionTypesId = 1
                },
                new User
                {
                    Id = 10,
                    Name = "Ava",
                    LastName = "Anderson",
                    Email = "ava.anderson@hotmail.com",
                    Password = "AQAAAAIAAYagAAAAENNiUrRyyMsKBHWjGJkxcaggGlz/w55oHx+JeoBE91Vq8ufWIElWX3S0cz9gfbPT4A==",// patu
                    SubscriptionTypesId = 2
                }

            );
        }
    }

}