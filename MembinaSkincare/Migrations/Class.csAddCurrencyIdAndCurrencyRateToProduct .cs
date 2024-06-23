using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddCurrencyIdAndCurrencyRateToProduct : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "CurrencyId",
            table: "Products",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<decimal>(
            name: "CurrencyRate",
            table: "Products",
            type: "decimal(18, 2)",
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.CreateIndex(
            name: "IX_Products_CurrencyId",
            table: "Products",
            column: "CurrencyId");

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

        migrationBuilder.DropIndex(
            name: "IX_Products_CurrencyId",
            table: "Products");

        migrationBuilder.DropColumn(
            name: "CurrencyId",
            table: "Products");

        migrationBuilder.DropColumn(
            name: "CurrencyRate",
            table: "Products");
    }
}
