using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut_2.Migrations
{
    public partial class AddedExpenseTypeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpTypeId",
                table: "Expenses",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpTypeId",
                table: "Expenses",
                column: "ExpTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpTypeId",
                table: "Expenses",
                column: "ExpTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpTypeId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpTypeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpTypeId",
                table: "Expenses");
        }
    }
}
