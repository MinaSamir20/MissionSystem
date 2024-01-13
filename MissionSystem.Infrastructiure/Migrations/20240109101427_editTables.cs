using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionSystem.Infrastructiure.Migrations
{
    /// <inheritdoc />
    public partial class editTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Missions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Missions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
