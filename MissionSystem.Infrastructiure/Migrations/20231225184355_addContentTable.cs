using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionSystem.Infrastructiure.Migrations
{
    /// <inheritdoc />
    public partial class addContentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Governments_GovernmentId",
                table: "Schools");

            migrationBuilder.DropTable(
                name: "CategoryMission");

            migrationBuilder.DropIndex(
                name: "IX_Schools_GovernmentId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "GovernmentId",
                table: "Schools");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Missions",
                newName: "Suggestion");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Missions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Missions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Satisfaction",
                table: "Missions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContentDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentDetails_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_CategoryId",
                table: "Missions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentDetails_MissionId",
                table: "ContentDetails",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Categories_CategoryId",
                table: "Missions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Categories_CategoryId",
                table: "Missions");

            migrationBuilder.DropTable(
                name: "ContentDetails");

            migrationBuilder.DropIndex(
                name: "IX_Missions_CategoryId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Satisfaction",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "Suggestion",
                table: "Missions",
                newName: "Content");

            migrationBuilder.AddColumn<Guid>(
                name: "GovernmentId",
                table: "Schools",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryMission",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMission", x => new { x.CategoryId, x.MissionId });
                    table.ForeignKey(
                        name: "FK_CategoryMission_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMission_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schools_GovernmentId",
                table: "Schools",
                column: "GovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMission_MissionId",
                table: "CategoryMission",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Governments_GovernmentId",
                table: "Schools",
                column: "GovernmentId",
                principalTable: "Governments",
                principalColumn: "Id");
        }
    }
}
