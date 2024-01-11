using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dosLogistic.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAndCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e9128a8-6c64-4964-ba12-d650b5187b6d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c030d829-7f17-4f99-a888-ebc4f1acbc02"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Receivers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "Receivers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7c61e341-8a03-4569-948e-00175db2509b"), new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3775), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("90c74c2d-f619-421b-bb98-317a00d01104"), new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3818), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 22, 20, 16, 27, 162, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 5, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7c61e341-8a03-4569-948e-00175db2509b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90c74c2d-f619-421b-bb98-317a00d01104"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Receivers");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3e9128a8-6c64-4964-ba12-d650b5187b6d"), new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1633), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("c030d829-7f17-4f99-a888-ebc4f1acbc02"), new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 5, 0, 0, 0)) }
                });
        }
    }
}
