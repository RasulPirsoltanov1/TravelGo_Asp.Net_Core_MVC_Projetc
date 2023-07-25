using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class subaboutchangew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubAbout2Id",
                table: "SubAbouts",
                newName: "SubAboutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubAboutId",
                table: "SubAbouts",
                newName: "SubAbout2Id");
        }
    }
}
