using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zenny_Api.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class UserSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "subscription_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    subscription_type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    last_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    email = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    password = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    subscription_types_id = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "last_name", "name", "password", "subscription_types_id" },
                values: new object[,]
                {
                    { 1u, "john.doe@gmail.com", "Doe", "John", "AQAAAAIAAYagAAAAEMdFhcD1F5/AEIUpec2VvWSdPRIoL1XQhv3ZUD1vLeOPjH5Hd9ttkWii7vYBDbIAOg==", 1 },
                    { 2u, "jane.smith@gmail.com", "Smith", "Jane", "AQAAAAIAAYagAAAAEOL51N9ITma/uetBXtmwTKwB1jYW2gh1Lu+7IoUn10LDiZLjLeP9cmYD9mX4X6l//A==", 1 },
                    { 3u, "Jhonh@gmail.com", "gency", "John", "AQAAAAIAAYagAAAAEMy9Y8UXBvAToeGTkAESFaQ/+BOQyfh9PvKUtcLY5F3ux0UwzxIJguH/yCJMdPgs5Q==", 1 },
                    { 4u, "david.williams@gmail.com", "Williams", "David", "AQAAAAIAAYagAAAAEMwLpIDa/KH8lpkhv+GoRPyUanbnKOVkWTqFCyOEtgRRFDDlXIm5wAjbxEjpSArWtA==", 1 },
                    { 5u, "sophia.davis@gmail.com", "Davis", "Sophia", "AQAAAAIAAYagAAAAECA8MhaHudUaw8vPoZzVNieeQ5+IL4WxitfJKupeZcEo5ETbvyilMLw/wSdIXaKBkg==", 2 },
                    { 6u, "james.miller@hotmail.com", "Miller", "James", "AQAAAAIAAYagAAAAEIEN9uyCQUtm/qaVh/TFA/K2debhdvlNMKkWtgM3lQROQZyap9u/KqKcH+yUqhZE+w==", 1 },
                    { 7u, "isabella.garcia@hotmail.com", "Garcia", "Isabella", "AQAAAAIAAYagAAAAEO0qlrHwwg3pDj6pCoIrxgqX0kORKx8Bfzsdsi6/QRXOb9HrvtGz/TZ/6UpRi4cOig==", 1 },
                    { 8u, "emma.rodriguez@hotmail.com", "Rodriguez", "Emma", "AQAAAAIAAYagAAAAEO0qlrHwwg3pDj6pCoIrxgqX0kORKx8Bfzsdsi6/QRXOb9HrvtGz/TZ/6UpRi4cOig==", 2 },
                    { 9u, "olivia.wilson@hotmail.com", "Wilson", "Olivia", "AQAAAAIAAYagAAAAENNiUrRyyMsKBHWjGJkxcaggGlz/w55oHx+JeoBE91Vq8ufWIElWX3S0cz9gfbPT4A==", 1 },
                    { 10u, "ava.anderson@hotmail.com", "Anderson", "Ava", "AQAAAAIAAYagAAAAENNiUrRyyMsKBHWjGJkxcaggGlz/w55oHx+JeoBE91Vq8ufWIElWX3S0cz9gfbPT4A==", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "subscription_types",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "subscription_type_UNIQUE",
                table: "subscription_types",
                column: "subscription_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "email_UNIQUE",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "subscription_types_id",
                table: "users",
                column: "subscription_types_id");

            migrationBuilder.CreateIndex(
                name: "users_UNIQUE",
                table: "users",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscription_types");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
