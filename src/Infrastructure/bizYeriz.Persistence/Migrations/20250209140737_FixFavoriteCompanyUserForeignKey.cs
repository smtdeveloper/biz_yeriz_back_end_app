using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bizYeriz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixFavoriteCompanyUserForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCompanies_Users_CompanyId",
                table: "FavoriteCompanies");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Orders",
                newName: "OrderStatusType");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCompanies_UserId",
                table: "FavoriteCompanies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCompanies_Users_UserId",
                table: "FavoriteCompanies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCompanies_Users_UserId",
                table: "FavoriteCompanies");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteCompanies_UserId",
                table: "FavoriteCompanies");

            migrationBuilder.RenameColumn(
                name: "OrderStatusType",
                table: "Orders",
                newName: "OrderStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCompanies_Users_CompanyId",
                table: "FavoriteCompanies",
                column: "CompanyId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
