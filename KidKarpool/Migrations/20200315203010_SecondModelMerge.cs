using Microsoft.EntityFrameworkCore.Migrations;

namespace KidKarpool.Migrations
{
    public partial class SecondModelMerge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarMakeModel",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarMakeModel",
                table: "Requests");
        }
    }
}
