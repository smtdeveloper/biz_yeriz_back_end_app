using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bizYeriz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_new_company_average_rating_colm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d8744850-97a9-4893-8283-6078b9421d90"));

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Companies",
                type: "double precision",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("f4893d6e-e5c6-451a-af35-06f2042b1fca"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 23, 158, 223, 239, 76, 214, 30, 186, 255, 199, 205, 160, 13, 29, 41, 188, 244, 243, 12, 90, 208, 71, 221, 172, 158, 229, 111, 64, 190, 198, 204, 185, 131, 249, 180, 234, 42, 7, 232, 147, 72, 186, 221, 220, 118, 65, 116, 18, 27, 251, 232, 253, 196, 81, 29, 115, 151, 190, 43, 129, 85, 79, 102, 127 }, new byte[] { 205, 65, 24, 5, 126, 145, 145, 24, 181, 113, 168, 14, 251, 71, 127, 249, 84, 88, 209, 106, 192, 150, 37, 115, 71, 29, 95, 56, 7, 145, 196, 125, 156, 234, 104, 245, 8, 220, 7, 133, 7, 243, 176, 124, 156, 64, 157, 6, 85, 136, 232, 96, 114, 150, 63, 12, 30, 142, 95, 77, 174, 227, 56, 104, 97, 76, 70, 13, 146, 127, 120, 198, 200, 195, 77, 0, 82, 220, 109, 233, 148, 38, 46, 125, 83, 121, 158, 132, 231, 128, 69, 212, 110, 151, 129, 164, 57, 37, 110, 183, 230, 84, 115, 179, 241, 104, 244, 209, 231, 5, 121, 210, 62, 201, 20, 7, 96, 123, 66, 26, 8, 160, 34, 5, 143, 137, 20, 75 }, null, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f4893d6e-e5c6-451a-af35-06f2042b1fca"));

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("d8744850-97a9-4893-8283-6078b9421d90"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 14, 179, 207, 17, 27, 20, 34, 145, 250, 146, 162, 46, 184, 198, 56, 140, 84, 4, 180, 254, 240, 173, 249, 74, 94, 54, 211, 13, 31, 118, 221, 78, 103, 25, 195, 88, 48, 197, 77, 141, 98, 198, 26, 16, 86, 173, 29, 250, 19, 75, 88, 252, 101, 34, 202, 160, 172, 58, 49, 254, 139, 114, 147, 31 }, new byte[] { 137, 63, 146, 237, 239, 137, 217, 9, 104, 147, 161, 187, 73, 44, 240, 210, 53, 15, 209, 23, 69, 247, 246, 252, 37, 137, 247, 245, 125, 67, 177, 236, 197, 69, 106, 249, 157, 118, 184, 108, 79, 244, 156, 78, 93, 117, 186, 200, 39, 3, 117, 89, 165, 76, 59, 229, 12, 213, 142, 188, 243, 147, 110, 51, 166, 59, 187, 51, 85, 25, 141, 36, 10, 198, 46, 180, 78, 75, 79, 231, 136, 116, 211, 16, 185, 76, 240, 252, 147, 66, 154, 93, 46, 241, 141, 37, 251, 189, 85, 80, 162, 252, 98, 190, 127, 195, 176, 187, 40, 125, 191, 13, 44, 202, 231, 70, 207, 189, 48, 26, 166, 248, 110, 156, 126, 38, 187, 253 }, null, 0 });
        }
    }
}
