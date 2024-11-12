using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace bizYeriz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class companylocation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f4c3af2b-c5d5-4149-b9bd-8676aa78d3c7"));

            migrationBuilder.AlterColumn<Point>(
                name: "Location",
                table: "Companies",
                type: "geography (point)",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geometry",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("4f797fda-a4f8-48d6-9597-98f9ca61d523"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 230, 213, 172, 246, 25, 167, 203, 40, 94, 41, 109, 91, 107, 169, 235, 224, 88, 48, 221, 248, 181, 84, 114, 15, 76, 254, 90, 171, 72, 200, 41, 83, 124, 245, 75, 71, 25, 26, 69, 135, 58, 90, 63, 209, 87, 43, 184, 35, 98, 175, 247, 220, 77, 72, 96, 2, 60, 98, 124, 168, 182, 215, 0, 91 }, new byte[] { 32, 152, 216, 35, 252, 113, 115, 112, 206, 20, 173, 219, 159, 241, 248, 167, 146, 127, 13, 3, 35, 50, 153, 254, 205, 39, 4, 204, 45, 168, 227, 223, 102, 167, 106, 33, 168, 225, 110, 78, 249, 183, 107, 42, 91, 83, 6, 131, 7, 213, 254, 2, 185, 104, 245, 61, 75, 247, 195, 233, 122, 23, 42, 179, 218, 156, 119, 212, 168, 219, 225, 117, 200, 165, 193, 137, 38, 239, 218, 187, 209, 5, 201, 4, 59, 122, 240, 194, 142, 216, 78, 182, 183, 10, 221, 85, 12, 100, 152, 89, 62, 244, 77, 89, 136, 125, 77, 211, 193, 123, 103, 73, 33, 94, 139, 202, 110, 103, 119, 105, 247, 46, 56, 5, 234, 241, 137, 121 }, null, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4f797fda-a4f8-48d6-9597-98f9ca61d523"));

            migrationBuilder.AlterColumn<Point>(
                name: "Location",
                table: "Companies",
                type: "geometry",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geography (point)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("f4c3af2b-c5d5-4149-b9bd-8676aa78d3c7"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 38, 87, 136, 24, 53, 160, 15, 122, 210, 109, 174, 125, 226, 192, 81, 143, 26, 157, 235, 202, 16, 165, 80, 130, 121, 15, 159, 209, 225, 53, 83, 196, 138, 209, 94, 118, 185, 40, 65, 212, 231, 78, 210, 233, 186, 216, 190, 155, 116, 67, 39, 45, 247, 88, 155, 84, 128, 234, 146, 108, 205, 116, 203, 9 }, new byte[] { 48, 141, 38, 33, 71, 92, 2, 221, 143, 224, 0, 119, 47, 170, 221, 92, 48, 88, 60, 215, 114, 0, 53, 192, 81, 189, 197, 15, 22, 248, 132, 27, 40, 70, 234, 110, 147, 96, 61, 102, 139, 93, 156, 11, 120, 85, 80, 13, 60, 167, 19, 245, 198, 170, 215, 75, 38, 221, 225, 188, 29, 112, 36, 81, 142, 99, 22, 198, 240, 26, 16, 146, 23, 4, 44, 160, 87, 240, 107, 227, 133, 20, 122, 144, 123, 143, 186, 65, 247, 83, 47, 221, 109, 147, 234, 116, 102, 41, 80, 43, 91, 132, 250, 240, 149, 88, 190, 139, 69, 176, 120, 9, 166, 13, 219, 21, 166, 151, 161, 19, 141, 3, 30, 68, 122, 46, 125, 99 }, null, 0 });
        }
    }
}
