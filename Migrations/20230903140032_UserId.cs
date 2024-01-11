using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dosLogistic.API.Migrations
{
    /// <inheritdoc />
    public partial class UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("58ea85a8-3b51-425e-a0e8-7acf9209ce7d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("807cda8c-bd02-40e9-8102-bf71adea6c20"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Senders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Receivers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            /*migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6d0269ab-5672-4bac-bf30-c7d44b339a62"), new DateTimeOffset(new DateTime(2023, 9, 3, 19, 0, 32, 184, DateTimeKind.Unspecified).AddTicks(9264), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 3, 19, 0, 32, 184, DateTimeKind.Unspecified).AddTicks(9129), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 9, 3, 19, 0, 32, 184, DateTimeKind.Unspecified).AddTicks(9129), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("f0865b61-2c13-4b3f-93ea-d4040c4c5322"), new DateTimeOffset(new DateTime(2023, 9, 3, 19, 0, 32, 184, DateTimeKind.Unspecified).AddTicks(9227), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 3, 19, 0, 32, 184, DateTimeKind.Unspecified).AddTicks(9129), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 9, 3, 19, 0, 32, 184, DateTimeKind.Unspecified).AddTicks(9129), new TimeSpan(0, 5, 0, 0, 0)) }
                });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d0269ab-5672-4bac-bf30-c7d44b339a62"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f0865b61-2c13-4b3f-93ea-d4040c4c5322"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Senders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Receivers");

            /*migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("58ea85a8-3b51-425e-a0e8-7acf9209ce7d"), new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("807cda8c-bd02-40e9-8102-bf71adea6c20"), new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 5, 0, 0, 0)) }
                });*/
        }
    }
}
