using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachinesTelemetry.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToMachine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Telemetries_LastTelemetryId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_LastTelemetryId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "LastTelemetryID",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "LastTelemetryId",
                table: "Machines");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Machines",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Machines");

            migrationBuilder.AddColumn<Guid>(
                name: "LastTelemetryID",
                table: "Machines",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastTelemetryId",
                table: "Machines",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_LastTelemetryId",
                table: "Machines",
                column: "LastTelemetryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Telemetries_LastTelemetryId",
                table: "Machines",
                column: "LastTelemetryId",
                principalTable: "Telemetries",
                principalColumn: "Id");
        }
    }
}
