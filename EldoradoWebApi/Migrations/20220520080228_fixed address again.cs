using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EldoradoWebApi.Migrations
{
    public partial class fixedaddressagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Adresses",
                newName: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Adresses",
                newName: "UserId");
        }
    }
}
