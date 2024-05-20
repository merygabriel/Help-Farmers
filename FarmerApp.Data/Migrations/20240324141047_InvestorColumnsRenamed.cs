using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InvestorColumnsRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseName",
                table: "Expenses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ExpenseAmount",
                table: "Expenses",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Expenses",
                newName: "ExpenseName");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Expenses",
                newName: "ExpenseAmount");
        }
    }
}
