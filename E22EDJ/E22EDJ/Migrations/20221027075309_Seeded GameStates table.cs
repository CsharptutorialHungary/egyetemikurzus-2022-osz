using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E22EDJ.Migrations
{
    public partial class SeededGameStatestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GameStates",
                columns: new[] { "GameStateId", "IsDeleted", "Name" },
                values: new object[] { 1, false, "Planned" });

            migrationBuilder.InsertData(
                table: "GameStates",
                columns: new[] { "GameStateId", "IsDeleted", "Name" },
                values: new object[] { 2, false, "On Going" });

            migrationBuilder.InsertData(
                table: "GameStates",
                columns: new[] { "GameStateId", "IsDeleted", "Name" },
                values: new object[] { 3, false, "Completed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameStates",
                keyColumn: "GameStateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameStates",
                keyColumn: "GameStateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameStates",
                keyColumn: "GameStateId",
                keyValue: 3);
        }
    }
}
