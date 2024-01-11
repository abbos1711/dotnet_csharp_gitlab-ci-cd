using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dosLogistic.API.Migrations
{
    /// <inheritdoc />
    public partial class addSenderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Sender_SenderId",
                table: "Parcels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sender",
                table: "Sender");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a51d98f-8018-4167-9722-5c222f223432"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("363ed761-2d79-4c80-9a6e-1a1fd2deca83"));

            migrationBuilder.RenameTable(
                name: "Sender",
                newName: "Senders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Senders",
                table: "Senders",
                column: "Id");

            /*migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("58ea85a8-3b51-425e-a0e8-7acf9209ce7d"), new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("807cda8c-bd02-40e9-8102-bf71adea6c20"), new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 30, 20, 18, 41, 431, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 5, 0, 0, 0)) }
                });*/

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Senders_SenderId",
                table: "Parcels",
                column: "SenderId",
                principalTable: "Senders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Senders_SenderId",
                table: "Parcels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Senders",
                table: "Senders");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("58ea85a8-3b51-425e-a0e8-7acf9209ce7d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("807cda8c-bd02-40e9-8102-bf71adea6c20"));

            migrationBuilder.RenameTable(
                name: "Senders",
                newName: "Sender");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sender",
                table: "Sender",
                column: "Id");

            /*migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0a51d98f-8018-4167-9722-5c222f223432"), new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(9119), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("363ed761-2d79-4c80-9a6e-1a1fd2deca83"), new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(9069), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 5, 0, 0, 0)) }
                });*/

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Sender_SenderId",
                table: "Parcels",
                column: "SenderId",
                principalTable: "Sender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
