using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbanMate.Data.Migrations
{
    public partial class adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phases_tasks_TaskId",
                table: "phases");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_phases_PhaseId",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_projects_PhaseId",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_phases_TaskId",
                table: "phases");

            migrationBuilder.DropColumn(
                name: "PhaseId",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "phases");

            migrationBuilder.AddColumn<int>(
                name: "phaseId",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "projectId",
                table: "phases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AppUserProject",
                columns: table => new
                {
                    projectsId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserProject", x => new { x.projectsId, x.usersId });
                    table.ForeignKey(
                        name: "FK_AppUserProject_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserProject_projects_projectsId",
                        column: x => x.projectsId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_phaseId",
                table: "tasks",
                column: "phaseId");

            migrationBuilder.CreateIndex(
                name: "IX_phases_projectId",
                table: "phases",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProject_usersId",
                table: "AppUserProject",
                column: "usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_phases_projects_projectId",
                table: "phases",
                column: "projectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_phases_phaseId",
                table: "tasks",
                column: "phaseId",
                principalTable: "phases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phases_projects_projectId",
                table: "phases");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_phases_phaseId",
                table: "tasks");

            migrationBuilder.DropTable(
                name: "AppUserProject");

            migrationBuilder.DropIndex(
                name: "IX_tasks_phaseId",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_phases_projectId",
                table: "phases");

            migrationBuilder.DropColumn(
                name: "phaseId",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "projectId",
                table: "phases");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "PhaseId",
                table: "projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "phases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_projects_PhaseId",
                table: "projects",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_phases_TaskId",
                table: "phases",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_phases_tasks_TaskId",
                table: "phases",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_phases_PhaseId",
                table: "projects",
                column: "PhaseId",
                principalTable: "phases",
                principalColumn: "Id");
        }
    }
}
