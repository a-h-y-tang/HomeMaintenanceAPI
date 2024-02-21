using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class V1InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceCycleTask",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskFrequency = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceCycleTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskExecutionHistory",
                columns: table => new
                {
                    TaskExecutionKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskKey = table.Column<long>(type: "bigint", nullable: false),
                    TaskExecutionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskPerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskExecutionHistory", x => x.TaskExecutionKey);
                    table.ForeignKey(
                        name: "FK_TaskExecutionHistory_MaintenanceCycleTask_TaskKey",
                        column: x => x.TaskKey,
                        principalTable: "MaintenanceCycleTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceCycleTask_Id",
                table: "MaintenanceCycleTask",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskExecutionHistory_TaskExecutionKey",
                table: "TaskExecutionHistory",
                column: "TaskExecutionKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskExecutionHistory_TaskKey",
                table: "TaskExecutionHistory",
                column: "TaskKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskExecutionHistory");

            migrationBuilder.DropTable(
                name: "MaintenanceCycleTask");
        }
    }
}
