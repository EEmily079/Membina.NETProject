using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MembinaSkincare.Migrations
{
    public partial class addnewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Currency_CurrencyRateId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Products_CurrencyRateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CurrencyRateId",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "CurrencyRate",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyRate",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyRateId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrencyRateId",
                table: "Products",
                column: "CurrencyRateId");

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
