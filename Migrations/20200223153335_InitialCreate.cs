using Microsoft.EntityFrameworkCore.Migrations;

namespace MparWinForm07.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actioncode",
                columns: table => new
                {
                    Actioncode = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actioncode", x => x.Actioncode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actioncode");
        }
    }
}
