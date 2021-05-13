using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class add_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Activities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Activities");
        }
    }
}
