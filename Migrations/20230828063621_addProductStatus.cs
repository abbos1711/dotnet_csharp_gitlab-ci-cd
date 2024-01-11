using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dosLogistic.API.Migrations
{
    /// <inheritdoc />
    public partial class addProductStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1a05ea9d-776d-40bc-84c6-cf6a7979b172"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("73965a93-b16a-4358-b77a-9ffc573d39fe"));

            migrationBuilder.AddColumn<int>(
                name: "ProductStatus",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            /*migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                   // { new Guid("c2a629c7-59ca-4b8f-be6c-e39fd9d508f1"), new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 5, 0, 0, 0)) },
                   // { new Guid("fce5e92c-d983-4e5b-8cce-a3ce9939cd38"), new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 5, 0, 0, 0)) }
                });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c2a629c7-59ca-4b8f-be6c-e39fd9d508f1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fce5e92c-d983-4e5b-8cce-a3ce9939cd38"));

            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "Products");

            /*migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                   // { new Guid("1a05ea9d-776d-40bc-84c6-cf6a7979b172"), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6512), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 5, 0, 0, 0)) },
                    //{ new Guid("73965a93-b16a-4358-b77a-9ffc573d39fe"), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6472), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 23, 2, 10, 42, 979, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 5, 0, 0, 0)) }
                });*/
        }
    }
}
