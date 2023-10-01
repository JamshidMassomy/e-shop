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
                    { new Guid("c44a0000-647a-e86a-38eb-08dbc2476425"), new DateTime(2023, 10, 1, 9, 26, 48, 168, DateTimeKind.Local).AddTicks(4730), "Apple Iphone newest product", "Iphone14", 900m, new DateTime(2023, 10, 1, 9, 26, 48, 168, DateTimeKind.Local).AddTicks(4771) },
                    { new Guid("c44a0000-647a-e86a-3925-08dbc2476425"), new DateTime(2023, 10, 1, 9, 26, 48, 168, DateTimeKind.Local).AddTicks(4774), "Andriod Mobile phone", "Andriod", 800m, new DateTime(2023, 10, 1, 9, 26, 48, 168, DateTimeKind.Local).AddTicks(4776) },
                    { new Guid("c44a0000-647a-e86a-392c-08dbc2476425"), new DateTime(2023, 10, 1, 9, 26, 48, 168, DateTimeKind.Local).AddTicks(4781), "Dell Laptop", "Laptop", 700m, new DateTime(2023, 10, 1, 9, 26, 48, 168, DateTimeKind.Local).AddTicks(4782) }
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
