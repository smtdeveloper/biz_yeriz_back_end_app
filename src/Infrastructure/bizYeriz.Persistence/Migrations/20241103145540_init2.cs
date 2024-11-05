using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bizYeriz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6a0e369c-be51-4c26-b496-496c08debe78"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("3a6692b6-b941-4ff0-a594-9a7ae639bc1c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 135, 179, 126, 57, 1, 210, 176, 6, 215, 71, 177, 200, 79, 59, 131, 16, 171, 3, 127, 145, 10, 20, 244, 131, 141, 244, 60, 140, 72, 54, 226, 131, 245, 21, 43, 108, 75, 207, 143, 143, 34, 230, 109, 143, 126, 23, 151, 255, 163, 197, 37, 149, 79, 58, 244, 113, 149, 48, 113, 157, 177, 125, 121, 9 }, new byte[] { 226, 38, 17, 10, 141, 90, 21, 215, 24, 71, 252, 76, 122, 242, 237, 143, 232, 226, 89, 197, 97, 129, 13, 118, 113, 83, 32, 54, 146, 152, 146, 179, 25, 9, 153, 88, 253, 27, 125, 239, 8, 228, 124, 89, 16, 79, 74, 75, 6, 157, 103, 242, 251, 71, 7, 171, 212, 115, 231, 182, 202, 220, 143, 73, 27, 244, 58, 162, 60, 238, 242, 4, 58, 164, 240, 0, 178, 203, 25, 174, 112, 179, 90, 164, 218, 212, 12, 175, 197, 68, 33, 44, 113, 250, 68, 32, 48, 180, 136, 252, 115, 219, 27, 176, 55, 108, 224, 95, 136, 166, 42, 241, 36, 30, 159, 245, 233, 205, 185, 232, 106, 245, 60, 252, 124, 184, 27, 123 }, null, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a6692b6-b941-4ff0-a594-9a7ae639bc1c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("6a0e369c-be51-4c26-b496-496c08debe78"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 40, 11, 209, 120, 148, 228, 23, 176, 189, 227, 119, 104, 104, 125, 169, 158, 53, 25, 198, 97, 45, 158, 67, 2, 26, 113, 98, 111, 64, 146, 130, 187, 214, 6, 203, 178, 142, 65, 165, 136, 132, 133, 82, 167, 180, 23, 47, 99, 43, 95, 239, 107, 121, 172, 42, 175, 87, 95, 255, 148, 195, 254, 30, 238 }, new byte[] { 105, 110, 70, 102, 103, 242, 1, 213, 75, 37, 105, 249, 233, 6, 45, 215, 179, 184, 187, 14, 187, 10, 181, 122, 255, 24, 63, 205, 86, 89, 220, 34, 100, 179, 155, 37, 53, 213, 162, 172, 117, 184, 16, 191, 22, 148, 117, 135, 236, 148, 212, 186, 95, 253, 131, 206, 49, 73, 7, 47, 12, 120, 247, 190, 39, 240, 38, 80, 74, 99, 85, 173, 40, 166, 143, 25, 183, 208, 156, 29, 62, 138, 239, 119, 146, 215, 136, 26, 145, 51, 9, 166, 206, 225, 247, 168, 75, 255, 244, 251, 118, 181, 250, 120, 10, 144, 224, 55, 206, 34, 84, 3, 68, 82, 85, 126, 150, 233, 72, 6, 84, 21, 88, 122, 117, 221, 216, 153 }, null, 0 });
        }
    }
}
