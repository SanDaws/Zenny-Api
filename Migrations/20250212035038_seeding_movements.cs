using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zenny_Api.Migrations
{
    /// <inheritdoc />
    public partial class seeding_movements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[] { 1u, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 10000.0 });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "categories_id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[,]
                {
                    { 2u, 1, new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5000.0 },
                    { 3u, 2, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2000.0 }
                });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[] { 4u, new DateTime(2024, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 15000.0 });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "categories_id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[,]
                {
                    { 5u, 4, new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 7000.0 },
                    { 6u, 5, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 3000.0 }
                });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[] { 7u, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 25000.0 });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "categories_id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[,]
                {
                    { 8u, 3, new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 12000.0 },
                    { 9u, 6, new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[] { 10u, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 20000.0 });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "categories_id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[,]
                {
                    { 11u, 7, new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 10000.0 },
                    { 12u, 8, new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 4000.0 }
                });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[] { 13u, new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 35000.0 });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "categories_id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[,]
                {
                    { 14u, 9, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 18000.0 },
                    { 15u, 10, new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 6000.0 }
                });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[] { 16u, new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 22000.0 });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "categories_id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[,]
                {
                    { 17u, 11, new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 15000.0 },
                    { 18u, 12, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[] { 19u, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 40000.0 });

            migrationBuilder.InsertData(
                table: "movements",
                columns: new[] { "id", "categories_id", "movement_date", "transaction_types_id", "user_id", "value" },
                values: new object[] { 20u, 13, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 25000.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 6u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 7u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 8u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 9u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 10u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 11u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 12u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 13u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 14u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 15u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 16u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 17u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 18u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 19u);

            migrationBuilder.DeleteData(
                table: "movements",
                keyColumn: "id",
                keyValue: 20u);
        }
    }
}
