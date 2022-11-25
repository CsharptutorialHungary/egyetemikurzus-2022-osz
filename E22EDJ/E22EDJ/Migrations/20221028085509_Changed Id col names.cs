using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E22EDJ.Migrations
{
    public partial class ChangedIdcolnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameStateId",
                table: "GameStates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Games",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GameStates",
                newName: "GameStateId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Games",
                newName: "GameId");
        }
    }
}
