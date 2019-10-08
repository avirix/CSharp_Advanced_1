using Microsoft.EntityFrameworkCore.Migrations;

namespace IteaLinqToSql.Migrations
{
    public partial class AddRealName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RealName",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealName",
                table: "Users");
        }
    }
}
