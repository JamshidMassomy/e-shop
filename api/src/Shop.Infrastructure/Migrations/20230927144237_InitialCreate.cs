using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("08160000-647a-e86a-fee6-08dbbf67fe82"), new DateTime(2023, 9, 27, 17, 42, 37, 559, DateTimeKind.Local).AddTicks(1669), "Apple Iphone newest product", "Iphone14", 900m, 2, new DateTime(2023, 9, 27, 17, 42, 37, 559, DateTimeKind.Local).AddTicks(1700) },
                    { new Guid("08160000-647a-e86a-ff16-08dbbf67fe82"), new DateTime(2023, 9, 27, 17, 42, 37, 559, DateTimeKind.Local).AddTicks(1704), "Andriod Mobile phone", "Andriod", 800m, 5, new DateTime(2023, 9, 27, 17, 42, 37, 559, DateTimeKind.Local).AddTicks(1705) },
                    { new Guid("08160000-647a-e86a-ff1b-08dbbf67fe82"), new DateTime(2023, 9, 27, 17, 42, 37, 559, DateTimeKind.Local).AddTicks(1708), "Dell Laptop", "Laptop", 700m, 6, new DateTime(2023, 9, 27, 17, 42, 37, 559, DateTimeKind.Local).AddTicks(1710) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
