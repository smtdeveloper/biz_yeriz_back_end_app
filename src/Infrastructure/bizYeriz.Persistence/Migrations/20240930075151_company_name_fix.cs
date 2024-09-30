using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bizYeriz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class company_name_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95043dc5-35a6-4868-940a-5616c1fe9427"));

            migrationBuilder.RenameColumn(
                name: "Neighbarhood",
                table: "Companies",
                newName: "Neighborhood");

            migrationBuilder.RenameColumn(
                name: "AddreesDetail",
                table: "Companies",
                newName: "AddressDetail");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("6a0e369c-be51-4c26-b496-496c08debe78"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 40, 11, 209, 120, 148, 228, 23, 176, 189, 227, 119, 104, 104, 125, 169, 158, 53, 25, 198, 97, 45, 158, 67, 2, 26, 113, 98, 111, 64, 146, 130, 187, 214, 6, 203, 178, 142, 65, 165, 136, 132, 133, 82, 167, 180, 23, 47, 99, 43, 95, 239, 107, 121, 172, 42, 175, 87, 95, 255, 148, 195, 254, 30, 238 }, new byte[] { 105, 110, 70, 102, 103, 242, 1, 213, 75, 37, 105, 249, 233, 6, 45, 215, 179, 184, 187, 14, 187, 10, 181, 122, 255, 24, 63, 205, 86, 89, 220, 34, 100, 179, 155, 37, 53, 213, 162, 172, 117, 184, 16, 191, 22, 148, 117, 135, 236, 148, 212, 186, 95, 253, 131, 206, 49, 73, 7, 47, 12, 120, 247, 190, 39, 240, 38, 80, 74, 99, 85, 173, 40, 166, 143, 25, 183, 208, 156, 29, 62, 138, 239, 119, 146, 215, 136, 26, 145, 51, 9, 166, 206, 225, 247, 168, 75, 255, 244, 251, 118, 181, 250, 120, 10, 144, 224, 55, 206, 34, 84, 3, 68, 82, 85, 126, 150, 233, 72, 6, 84, 21, 88, 122, 117, 221, 216, 153 }, null, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6a0e369c-be51-4c26-b496-496c08debe78"));

            migrationBuilder.RenameColumn(
                name: "Neighborhood",
                table: "Companies",
                newName: "Neighbarhood");

            migrationBuilder.RenameColumn(
                name: "AddressDetail",
                table: "Companies",
                newName: "AddreesDetail");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("95043dc5-35a6-4868-940a-5616c1fe9427"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 89, 222, 232, 112, 7, 231, 9, 255, 97, 193, 124, 111, 163, 5, 218, 32, 193, 40, 29, 250, 231, 210, 150, 2, 255, 201, 192, 162, 43, 73, 213, 164, 145, 100, 8, 142, 172, 26, 144, 110, 39, 247, 216, 150, 138, 199, 8, 58, 169, 190, 55, 127, 86, 154, 255, 254, 182, 174, 146, 43, 192, 138, 142, 192 }, new byte[] { 210, 213, 240, 182, 87, 91, 73, 220, 172, 140, 79, 45, 176, 86, 33, 253, 246, 113, 163, 212, 20, 191, 28, 10, 8, 199, 221, 103, 53, 243, 55, 85, 239, 54, 147, 19, 51, 132, 72, 184, 159, 175, 230, 228, 51, 110, 50, 17, 120, 62, 54, 239, 81, 157, 47, 220, 119, 22, 215, 9, 235, 57, 168, 109, 28, 116, 137, 153, 16, 75, 26, 238, 133, 58, 21, 139, 218, 241, 113, 240, 156, 153, 18, 62, 212, 1, 207, 75, 7, 238, 233, 250, 253, 16, 67, 102, 218, 89, 75, 250, 14, 54, 219, 227, 197, 218, 48, 91, 57, 128, 240, 216, 193, 17, 84, 205, 255, 195, 36, 146, 182, 166, 3, 70, 87, 46, 202, 42 }, null, 0 });
        }
    }
}
