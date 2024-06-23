using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MembinaSkincare.Migrations
{
    public partial class Updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Currency_CurrencyRateId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CurrencyRateId",
                table: "Products",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CurrencyRateId",
                table: "Products",
                newName: "IX_Products_CurrencyId");

            migrationBuilder.AlterColumn<decimal>(
                name: "SGDPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "MMKPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyRate",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrencyRate",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyName",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Currency_CurrencyId",
                table: "Products",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Currency_CurrencyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CurrencyRate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "Currency");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Products",
                newName: "CurrencyRateId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CurrencyId",
                table: "Products",
                newName: "IX_Products_CurrencyRateId");

            migrationBuilder.AlterColumn<double>(
                name: "SGDPrice",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "MMKPrice",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "CurrencyRate",
                table: "Currency",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Currency_CurrencyRateId",
                table: "Products",
                column: "CurrencyRateId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
