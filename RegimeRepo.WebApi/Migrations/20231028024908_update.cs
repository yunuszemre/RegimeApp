using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegimeRepo.WebApi.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fails",
                table: "Regimes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fails",
                table: "Regimes");
        }
    }
}
