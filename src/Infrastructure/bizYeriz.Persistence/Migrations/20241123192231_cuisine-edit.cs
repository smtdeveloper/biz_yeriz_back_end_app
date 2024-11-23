using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bizYeriz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cuisineedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuisineCategories_Companies_CompanyId",
                table: "CuisineCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_CuisineCategories_CuisineCategoryId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_CuisineCategoryId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_CuisineCategories_CompanyId",
                table: "CuisineCategories");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4f797fda-a4f8-48d6-9597-98f9ca61d523"));

            migrationBuilder.DropColumn(
                name: "CuisineCategoryId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CuisineCategories");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("b61191f1-7230-4590-914a-d9ba377c43b7"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 128, 255, 167, 30, 76, 40, 57, 68, 145, 221, 20, 49, 91, 255, 214, 77, 213, 223, 208, 31, 17, 250, 109, 223, 244, 191, 184, 226, 52, 59, 215, 125, 40, 26, 225, 142, 195, 239, 220, 31, 146, 161, 102, 38, 236, 230, 15, 100, 64, 49, 5, 106, 91, 125, 19, 67, 45, 83, 32, 0, 82, 99, 97, 186 }, new byte[] { 36, 205, 50, 93, 216, 27, 92, 53, 237, 232, 91, 209, 19, 198, 134, 97, 60, 71, 35, 90, 200, 115, 94, 171, 125, 183, 143, 81, 101, 245, 221, 70, 136, 98, 129, 66, 126, 211, 4, 206, 214, 109, 199, 88, 35, 125, 125, 70, 67, 46, 246, 194, 236, 247, 106, 166, 93, 241, 138, 213, 19, 236, 77, 127, 174, 151, 212, 94, 73, 165, 110, 33, 87, 155, 253, 4, 7, 102, 67, 156, 148, 222, 100, 20, 247, 37, 124, 30, 38, 130, 236, 246, 210, 154, 101, 253, 33, 212, 174, 138, 159, 107, 29, 236, 127, 166, 189, 25, 121, 54, 24, 211, 207, 181, 170, 187, 22, 22, 133, 255, 232, 48, 31, 17, 82, 128, 187, 240 }, null, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b61191f1-7230-4590-914a-d9ba377c43b7"));

            migrationBuilder.AddColumn<int>(
                name: "CuisineCategoryId",
                table: "Foods",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "CuisineCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("4f797fda-a4f8-48d6-9597-98f9ca61d523"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 230, 213, 172, 246, 25, 167, 203, 40, 94, 41, 109, 91, 107, 169, 235, 224, 88, 48, 221, 248, 181, 84, 114, 15, 76, 254, 90, 171, 72, 200, 41, 83, 124, 245, 75, 71, 25, 26, 69, 135, 58, 90, 63, 209, 87, 43, 184, 35, 98, 175, 247, 220, 77, 72, 96, 2, 60, 98, 124, 168, 182, 215, 0, 91 }, new byte[] { 32, 152, 216, 35, 252, 113, 115, 112, 206, 20, 173, 219, 159, 241, 248, 167, 146, 127, 13, 3, 35, 50, 153, 254, 205, 39, 4, 204, 45, 168, 227, 223, 102, 167, 106, 33, 168, 225, 110, 78, 249, 183, 107, 42, 91, 83, 6, 131, 7, 213, 254, 2, 185, 104, 245, 61, 75, 247, 195, 233, 122, 23, 42, 179, 218, 156, 119, 212, 168, 219, 225, 117, 200, 165, 193, 137, 38, 239, 218, 187, 209, 5, 201, 4, 59, 122, 240, 194, 142, 216, 78, 182, 183, 10, 221, 85, 12, 100, 152, 89, 62, 244, 77, 89, 136, 125, 77, 211, 193, 123, 103, 73, 33, 94, 139, 202, 110, 103, 119, 105, 247, 46, 56, 5, 234, 241, 137, 121 }, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CuisineCategoryId",
                table: "Foods",
                column: "CuisineCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CuisineCategories_CompanyId",
                table: "CuisineCategories",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuisineCategories_Companies_CompanyId",
                table: "CuisineCategories",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_CuisineCategories_CuisineCategoryId",
                table: "Foods",
                column: "CuisineCategoryId",
                principalTable: "CuisineCategories",
                principalColumn: "Id");
        }
    }
}
