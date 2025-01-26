using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SlateID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectionSource = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Team = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projection_Slates_SlateID",
                        column: x => x.SlateID,
                        principalTable: "Slates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectionData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectionData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectionData_Projection_ProjectionId",
                        column: x => x.ProjectionId,
                        principalTable: "Projection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projection_SlateID",
                table: "Projection",
                column: "SlateID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionData_ProjectionId",
                table: "ProjectionData",
                column: "ProjectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectionData");

            migrationBuilder.DropTable(
                name: "Projection");
        }
    }
}
