using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste.Business.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "VALOR",
                table: "PRODUTOS",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VALOR",
                table: "PRODUTOS");
        }
    }
}
