using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bizYeriz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class food_orginalPrice_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f4893d6e-e5c6-451a-af35-06f2042b1fca"));

            migrationBuilder.RenameColumn(
                name: "OrjinalPrice",
                table: "Foods",
                newName: "OriginalPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OriginalPrice",
                table: "Foods",
                newName: "OrjinalPrice");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("f4893d6e-e5c6-451a-af35-06f2042b1fca"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 23, 158, 223, 239, 76, 214, 30, 186, 255, 199, 205, 160, 13, 29, 41, 188, 244, 243, 12, 90, 208, 71, 221, 172, 158, 229, 111, 64, 190, 198, 204, 185, 131, 249, 180, 234, 42, 7, 232, 147, 72, 186, 221, 220, 118, 65, 116, 18, 27, 251, 232, 253, 196, 81, 29, 115, 151, 190, 43, 129, 85, 79, 102, 127 }, new byte[] { 205, 65, 24, 5, 126, 145, 145, 24, 181, 113, 168, 14, 251, 71, 127, 249, 84, 88, 209, 106, 192, 150, 37, 115, 71, 29, 95, 56, 7, 145, 196, 125, 156, 234, 104, 245, 8, 220, 7, 133, 7, 243, 176, 124, 156, 64, 157, 6, 85, 136, 232, 96, 114, 150, 63, 12, 30, 142, 95, 77, 174, 227, 56, 104, 97, 76, 70, 13, 146, 127, 120, 198, 200, 195, 77, 0, 82, 220, 109, 233, 148, 38, 46, 125, 83, 121, 158, 132, 231, 128, 69, 212, 110, 151, 129, 164, 57, 37, 110, 183, 230, 84, 115, 179, 241, 104, 244, 209, 231, 5, 121, 210, 62, 201, 20, 7, 96, 123, 66, 26, 8, 160, 34, 5, 143, 137, 20, 75 }, null, 0 });
        }
    }
}
