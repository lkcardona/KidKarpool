using Microsoft.EntityFrameworkCore.Migrations;

namespace KidKarpool.Migrations
{
    public partial class OneModelCombo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarMakeModel",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "DriverPhoneNumber",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentAcceptingName",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accept",
                columns: table => new
                {
                    AcceptID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(nullable: true),
                    ParentAcceptingName = table.Column<string>(nullable: true),
                    CarMakeModel = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accept", x => x.AcceptID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accept");

            migrationBuilder.DropColumn(
                name: "DriverPhoneNumber",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ParentAcceptingName",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "CarMakeModel",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
