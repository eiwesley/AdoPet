using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoPetApi.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoColunasPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdoptedDat",
                table: "Pets",
                newName: "AdoptedDate");

            migrationBuilder.AlterColumn<double>(
                name: "Age",
                table: "Pets",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdoptedDate",
                table: "Pets",
                newName: "AdoptedDat");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
