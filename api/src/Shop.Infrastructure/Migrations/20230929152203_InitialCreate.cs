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
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("28690000-647a-e86a-2cc2-08dbc0ffd5ab"), new DateTime(2023, 9, 29, 18, 22, 3, 701, DateTimeKind.Local).AddTicks(5758), "Apple Iphone newest product", "Iphone14", 900m, new DateTime(2023, 9, 29, 18, 22, 3, 701, DateTimeKind.Local).AddTicks(5796) },
                    { new Guid("28690000-647a-e86a-2cf6-08dbc0ffd5ab"), new DateTime(2023, 9, 29, 18, 22, 3, 701, DateTimeKind.Local).AddTicks(5799), "Andriod Mobile phone", "Andriod", 800m, new DateTime(2023, 9, 29, 18, 22, 3, 701, DateTimeKind.Local).AddTicks(5801) },
                    { new Guid("28690000-647a-e86a-2cfb-08dbc0ffd5ab"), new DateTime(2023, 9, 29, 18, 22, 3, 701, DateTimeKind.Local).AddTicks(5804), "Dell Laptop", "Laptop", 700m, new DateTime(2023, 9, 29, 18, 22, 3, 701, DateTimeKind.Local).AddTicks(5806) }
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
