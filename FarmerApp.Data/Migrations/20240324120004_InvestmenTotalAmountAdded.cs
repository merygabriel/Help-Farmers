using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InvestmenTotalAmountAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvestorId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_InvestorId",
                table: "Expenses",
                column: "InvestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Investors_InvestorId",
                table: "Expenses",
                column: "InvestorId",
                principalTable: "Investors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Investors_InvestorId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_InvestorId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "InvestorId",
                table: "Expenses");
        }
    }
}
