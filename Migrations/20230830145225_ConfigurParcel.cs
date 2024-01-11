using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dosLogistic.API.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurParcel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ProductType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Parcels");

            migrationBuilder.RenameColumn(
                name: "Subcategory",
                table: "Parcels",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Parcels",
                newName: "ParcelName");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Parcels",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParcelCountry",
                table: "Parcels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                table: "Parcels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "ServicePrice",
                table: "Parcels",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportJshshir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sender", x => x.Id);
                });

            /*migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0a51d98f-8018-4167-9722-5c222f223432"), new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(9119), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("363ed761-2d79-4c80-9a6e-1a1fd2deca83"), new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(9069), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 30, 19, 52, 25, 707, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 5, 0, 0, 0)) }
                });
*/
            migrationBuilder.CreateIndex(
                name: "IX_Parcels_SenderId",
                table: "Parcels",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Sender_SenderId",
                table: "Parcels",
                column: "SenderId",
                principalTable: "Sender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Sender_SenderId",
                table: "Parcels");

            migrationBuilder.DropTable(
                name: "Sender");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_SenderId",
                table: "Parcels");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a51d98f-8018-4167-9722-5c222f223432"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("363ed761-2d79-4c80-9a6e-1a1fd2deca83"));

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "ParcelCountry",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "Parcels");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Parcels",
                newName: "Subcategory");

            migrationBuilder.RenameColumn(
                name: "ParcelName",
                table: "Parcels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Parcels",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Parcels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            /* migrationBuilder.InsertData(
                 table: "Users",
                 columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "PassportJshshir", "PassportSeriesAndNumber", "Password", "PhoneNumber", "Role", "UpdatedDate" },
                 values: new object[,]
                 {
                     { new Guid("c2a629c7-59ca-4b8f-be6c-e39fd9d508f1"), new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 5, 0, 0, 0)), "ManagerAdmin@email.com", "Manager Admin", 0, "0", "0", "0", "Admin123!@#", "0", 1, new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 5, 0, 0, 0)) },
                     { new Guid("fce5e92c-d983-4e5b-8cce-a3ce9939cd38"), new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 5, 0, 0, 0)), "SuperAdmin@email.com", "Super Admin", 0, "0", "0", "0", "Admin123!@#", "0", 0, new DateTimeOffset(new DateTime(2023, 8, 28, 11, 36, 21, 675, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 5, 0, 0, 0)) }
                 });*/
        }
    }
}
