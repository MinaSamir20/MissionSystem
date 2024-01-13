using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionSystem.Infrastructiure.Migrations
{
    /// <inheritdoc />
    public partial class EditCoordinatorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoordinatorMission_Coordinators_CoordinatorsId",
                table: "CoordinatorMission");

            migrationBuilder.RenameColumn(
                name: "CoordinatorsId",
                table: "CoordinatorMission",
                newName: "CoordinatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoordinatorMission_Coordinators_CoordinatorId",
                table: "CoordinatorMission",
                column: "CoordinatorId",
                principalTable: "Coordinators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoordinatorMission_Coordinators_CoordinatorId",
                table: "CoordinatorMission");

            migrationBuilder.RenameColumn(
                name: "CoordinatorId",
                table: "CoordinatorMission",
                newName: "CoordinatorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoordinatorMission_Coordinators_CoordinatorsId",
                table: "CoordinatorMission",
                column: "CoordinatorsId",
                principalTable: "Coordinators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
