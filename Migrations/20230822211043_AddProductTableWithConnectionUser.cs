using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dosLogistic.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTableWithConnectionUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3082108a-0fba-4458-9884-a0f16760147c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("81c49d20-5ac1-4d51-976c-7b594d09a4e0"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1a05ea9d-776d-40bc-84c6-cf6a7979b172"), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6512), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("73965a93-b16a-4358-b77a-9ffc573d39fe"), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6472), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1a05ea9d-776d-40bc-84c6-cf6a7979b172"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("73965a93-b16a-4358-b77a-9ffc573d39fe"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3082108a-0fba-4458-9884-a0f16760147c"), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(5004), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("81c49d20-5ac1-4d51-976c-7b594d09a4e0"), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 23, 2, 9, 16, 879, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 5, 0, 0, 0)) }
                });
        }
    }
}
