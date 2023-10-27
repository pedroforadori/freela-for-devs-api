using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace freela_for_devs.Migrations
{
    /// <inheritdoc />
    public partial class newEntityProjectForengkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectsId",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectsId",
                table: "Projects",
                column: "ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Projects_ProjectsId",
                table: "Projects",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Projects_ProjectsId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectsId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectsId",
                table: "Projects");
        }
    }
}
