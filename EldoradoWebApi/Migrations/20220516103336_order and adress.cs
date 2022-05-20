using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EldoradoWebApi.Migrations
{
    public partial class orderandadress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Adresses_AdressEntityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AdressEntityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AdressEntityId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdressId",
                table: "Orders",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Adresses_AdressId",
                table: "Orders",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Adresses_AdressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AdressId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "AdressEntityId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdressEntityId",
                table: "Orders",
                column: "AdressEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Adresses_AdressEntityId",
                table: "Orders",
                column: "AdressEntityId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
