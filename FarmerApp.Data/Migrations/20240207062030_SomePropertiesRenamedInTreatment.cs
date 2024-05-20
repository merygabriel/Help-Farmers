using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SomePropertiesRenamedInTreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrugWeight",
                table: "Treatments");

            migrationBuilder.AddColumn<double>(
                name: "DrugAmount",
                table: "Treatments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementUnitId",
                table: "Treatments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_MeasurementUnitId",
                table: "Treatments",
                column: "MeasurementUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_MeasurementUnits_MeasurementUnitId",
                table: "Treatments",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_MeasurementUnits_MeasurementUnitId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_MeasurementUnitId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "DrugAmount",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "MeasurementUnitId",
                table: "Treatments");

            migrationBuilder.AddColumn<string>(
                name: "DrugWeight",
                table: "Treatments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
