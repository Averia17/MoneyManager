using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class update_account2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
