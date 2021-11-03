using Microsoft.EntityFrameworkCore.Migrations;

namespace JohannasReactProject.Data.Migrations
{
    public partial class budgetcategorygotuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BudgetCategories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCategories_UserId",
                table: "BudgetCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_AspNetUsers_UserId",
                table: "BudgetCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_AspNetUsers_UserId",
                table: "BudgetCategories");

            migrationBuilder.DropIndex(
                name: "IX_BudgetCategories_UserId",
                table: "BudgetCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BudgetCategories");
        }
    }
}
