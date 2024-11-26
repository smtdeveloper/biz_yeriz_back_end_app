using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bizYeriz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_new_filter_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b61191f1-7230-4590-914a-d9ba377c43b7"));

            migrationBuilder.CreateTable(
                name: "CompanyPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MinimumPoint = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinOrderAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinOrderAmounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPaymentType",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPaymentType", x => new { x.CompanyId, x.PaymentTypeId });
                    table.ForeignKey(
                        name: "FK_CompanyPaymentType_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyPaymentType_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("d8744850-97a9-4893-8283-6078b9421d90"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 14, 179, 207, 17, 27, 20, 34, 145, 250, 146, 162, 46, 184, 198, 56, 140, 84, 4, 180, 254, 240, 173, 249, 74, 94, 54, 211, 13, 31, 118, 221, 78, 103, 25, 195, 88, 48, 197, 77, 141, 98, 198, 26, 16, 86, 173, 29, 250, 19, 75, 88, 252, 101, 34, 202, 160, 172, 58, 49, 254, 139, 114, 147, 31 }, new byte[] { 137, 63, 146, 237, 239, 137, 217, 9, 104, 147, 161, 187, 73, 44, 240, 210, 53, 15, 209, 23, 69, 247, 246, 252, 37, 137, 247, 245, 125, 67, 177, 236, 197, 69, 106, 249, 157, 118, 184, 108, 79, 244, 156, 78, 93, 117, 186, 200, 39, 3, 117, 89, 165, 76, 59, 229, 12, 213, 142, 188, 243, 147, 110, 51, 166, 59, 187, 51, 85, 25, 141, 36, 10, 198, 46, 180, 78, 75, 79, 231, 136, 116, 211, 16, 185, 76, 240, 252, 147, 66, 154, 93, 46, 241, 141, 37, 251, 189, 85, 80, 162, 252, 98, 190, 127, 195, 176, 187, 40, 125, 191, 13, 44, 202, 231, 70, 207, 189, 48, 26, 166, 248, 110, 156, 126, 38, 187, 253 }, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPaymentType_PaymentTypeId",
                table: "CompanyPaymentType",
                column: "PaymentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyPaymentType");

            migrationBuilder.DropTable(
                name: "CompanyPoints");

            migrationBuilder.DropTable(
                name: "MinOrderAmounts");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d8744850-97a9-4893-8283-6078b9421d90"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "Gsm", "IsActive", "IsDelete", "LastName", "Name", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserType" },
                values: new object[] { new Guid("b61191f1-7230-4590-914a-d9ba377c43b7"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "codi@admin", null, false, false, "coder", "codi", new byte[] { 128, 255, 167, 30, 76, 40, 57, 68, 145, 221, 20, 49, 91, 255, 214, 77, 213, 223, 208, 31, 17, 250, 109, 223, 244, 191, 184, 226, 52, 59, 215, 125, 40, 26, 225, 142, 195, 239, 220, 31, 146, 161, 102, 38, 236, 230, 15, 100, 64, 49, 5, 106, 91, 125, 19, 67, 45, 83, 32, 0, 82, 99, 97, 186 }, new byte[] { 36, 205, 50, 93, 216, 27, 92, 53, 237, 232, 91, 209, 19, 198, 134, 97, 60, 71, 35, 90, 200, 115, 94, 171, 125, 183, 143, 81, 101, 245, 221, 70, 136, 98, 129, 66, 126, 211, 4, 206, 214, 109, 199, 88, 35, 125, 125, 70, 67, 46, 246, 194, 236, 247, 106, 166, 93, 241, 138, 213, 19, 236, 77, 127, 174, 151, 212, 94, 73, 165, 110, 33, 87, 155, 253, 4, 7, 102, 67, 156, 148, 222, 100, 20, 247, 37, 124, 30, 38, 130, 236, 246, 210, 154, 101, 253, 33, 212, 174, 138, 159, 107, 29, 236, 127, 166, 189, 25, 121, 54, 24, 211, 207, 181, 170, 187, 22, 22, 133, 255, 232, 48, 31, 17, 82, 128, 187, 240 }, null, 0 });
        }
    }
}
