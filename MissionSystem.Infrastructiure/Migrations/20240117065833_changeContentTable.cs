using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionSystem.Infrastructiure.Migrations
{
    /// <inheritdoc />
    public partial class changeContentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "ContentDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ContentDetails_CategoryId",
                table: "ContentDetails",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentDetails_Categories_CategoryId",
                table: "ContentDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentDetails_Categories_CategoryId",
                table: "ContentDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContentDetails_CategoryId",
                table: "ContentDetails");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ContentDetails");
        }
    }
}
