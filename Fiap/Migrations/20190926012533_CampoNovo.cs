using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Migrations
{
    public partial class CampoNovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MeuTimeDoCoracao",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeuTimeDoCoracao",
                table: "AspNetUsers");
        }
    }
}
