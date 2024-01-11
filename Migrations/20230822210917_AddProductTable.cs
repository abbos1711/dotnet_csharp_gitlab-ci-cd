using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dosLogistic.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7c61e341-8a03-4569-948e-00175db2509b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90c74c2d-f619-421b-bb98-317a00d01104"));

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Receivers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3082108a-0fba-4458-9884-a0f16760147c"), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(5004), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("81c49d20-5ac1-4d51-976c-7b594d09a4e0"), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReceiverId",
                table: "Products",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3082108a-0fba-4458-9884-a0f16760147c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("81c49d20-5ac1-4d51-976c-7b594d09a4e0"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7c61e341-8a03-4569-948e-00175db2509b"), new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3775), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("90c74c2d-f619-421b-bb98-317a00d01104"), new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3818), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 5, 0, 0, 0)) }
                });
        }
    }
}
