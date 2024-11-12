using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace bizYeriz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class companylocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a6692b6-b941-4ff0-a594-9a7ae639bc1c"));

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Companies");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.AddColumn<Point>(
                name: "Location",
                table: "Companies",
                type: "geometry",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("f4c3af2b-c5d5-4149-b9bd-8676aa78d3c7"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 38, 87, 136, 24, 53, 160, 15, 122, 210, 109, 174, 125, 226, 192, 81, 143, 26, 157, 235, 202, 16, 165, 80, 130, 121, 15, 159, 209, 225, 53, 83, 196, 138, 209, 94, 118, 185, 40, 65, 212, 231, 78, 210, 233, 186, 216, 190, 155, 116, 67, 39, 45, 247, 88, 155, 84, 128, 234, 146, 108, 205, 116, 203, 9 }, new byte[] { 48, 141, 38, 33, 71, 92, 2, 221, 143, 224, 0, 119, 47, 170, 221, 92, 48, 88, 60, 215, 114, 0, 53, 192, 81, 189, 197, 15, 22, 248, 132, 27, 40, 70, 234, 110, 147, 96, 61, 102, 139, 93, 156, 11, 120, 85, 80, 13, 60, 167, 19, 245, 198, 170, 215, 75, 38, 221, 225, 188, 29, 112, 36, 81, 142, 99, 22, 198, 240, 26, 16, 146, 23, 4, 44, 160, 87, 240, 107, 227, 133, 20, 122, 144, 123, 143, 186, 65, 247, 83, 47, 221, 109, 147, 234, 116, 102, 41, 80, 43, 91, 132, 250, 240, 149, 88, 190, 139, 69, 176, 120, 9, 166, 13, 219, 21, 166, 151, 161, 19, 141, 3, 30, 68, 122, 46, 125, 99 }, null, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f4c3af2b-c5d5-4149-b9bd-8676aa78d3c7"));

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Companies");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Companies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Long",
                table: "Companies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("3a6692b6-b941-4ff0-a594-9a7ae639bc1c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 135, 179, 126, 57, 1, 210, 176, 6, 215, 71, 177, 200, 79, 59, 131, 16, 171, 3, 127, 145, 10, 20, 244, 131, 141, 244, 60, 140, 72, 54, 226, 131, 245, 21, 43, 108, 75, 207, 143, 143, 34, 230, 109, 143, 126, 23, 151, 255, 163, 197, 37, 149, 79, 58, 244, 113, 149, 48, 113, 157, 177, 125, 121, 9 }, new byte[] { 226, 38, 17, 10, 141, 90, 21, 215, 24, 71, 252, 76, 122, 242, 237, 143, 232, 226, 89, 197, 97, 129, 13, 118, 113, 83, 32, 54, 146, 152, 146, 179, 25, 9, 153, 88, 253, 27, 125, 239, 8, 228, 124, 89, 16, 79, 74, 75, 6, 157, 103, 242, 251, 71, 7, 171, 212, 115, 231, 182, 202, 220, 143, 73, 27, 244, 58, 162, 60, 238, 242, 4, 58, 164, 240, 0, 178, 203, 25, 174, 112, 179, 90, 164, 218, 212, 12, 175, 197, 68, 33, 44, 113, 250, 68, 32, 48, 180, 136, 252, 115, 219, 27, 176, 55, 108, 224, 95, 136, 166, 42, 241, 36, 30, 159, 245, 233, 205, 185, 232, 106, 245, 60, 252, 124, 184, 27, 123 }, null, 0 });
        }
    }
}
