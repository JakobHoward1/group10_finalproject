using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Group10_FinalProject.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Review = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Name", "Rating", "Review", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("10101010-1010-1010-1010-101010101010"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia Brown", 3, "Portions were small", null },
                    { new Guid("20202020-2020-2020-2020-202020202020"), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Kim", 4, "Loved the pasta dishes", null },
                    { new Guid("30303030-3030-3030-3030-303030303030"), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia Martinez", 5, "Cozy place and tasty meals", null },
                    { new Guid("40404040-4040-4040-4040-404040404040"), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liam Davis", 3, "Could improve on the wait times", null },
                    { new Guid("50505050-5050-5050-5050-505050505050"), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ava Wilson", 5, "Fantastic experience overall", null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Simpson", 5, "Lovely establishment and the food was great", null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Susie Thomas", 4, "Great service", null },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Lee", 5, "The steak was amazing", null },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma Johnson", 3, "Friendly staff but a bit slow", null },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Ramirez", 5, "Excellent atmosphere and drinks", null }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "CreatedAt", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Main Course", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pan-Seared Steak", 30.00m, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Vegetarian", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mushroom Risotto", 24.00m, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Main Course", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grilled Salmon", 28.00m, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Vegetarian", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Margherita Pizza", 20.00m, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Vegetarian", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vegan Buddha Bowl", 22.00m, null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Main Course", new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken Alfredo Pasta", 25.00m, null },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Vegetarian", new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garden Salad", 18.00m, null },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Main Course", new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beef Burger", 21.00m, null },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Vegetarian", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spicy Tofu Stir-Fry", 23.00m, null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Main Course", new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lobster Bisque", 27.00m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedAt",
                table: "Customers",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Rating",
                table: "Customers",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_Category",
                table: "MenuItems",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CreatedAt",
                table: "MenuItems",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_Price",
                table: "MenuItems",
                column: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
