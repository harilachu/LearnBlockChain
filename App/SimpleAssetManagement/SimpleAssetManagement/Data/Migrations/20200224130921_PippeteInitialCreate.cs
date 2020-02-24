using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleAssetManagement.Data.Migrations
{
    public partial class PippeteInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Log_Id = table.Column<Guid>(nullable: false),
                    DateTimeStamp = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    Change = table.Column<int>(nullable: false),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Log_Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location_Id = table.Column<Guid>(nullable: false),
                    Location_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location_Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    Manufacture_Id = table.Column<Guid>(nullable: false),
                    Manufacture_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.Manufacture_Id);
                });

            migrationBuilder.CreateTable(
                name: "PippetteUsers",
                columns: table => new
                {
                    Pippette_User_Id = table.Column<Guid>(nullable: false),
                    Pippette_User_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PippetteUsers", x => x.Pippette_User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Pippettes",
                columns: table => new
                {
                    Pippette_Id = table.Column<Guid>(nullable: false),
                    Manufacture_Id = table.Column<Guid>(nullable: false),
                    Pippette_User_Id = table.Column<Guid>(nullable: false),
                    Location_Id = table.Column<Guid>(nullable: false),
                    ModelName = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    UsageFrequency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pippettes", x => x.Pippette_Id);
                    table.ForeignKey(
                        name: "FK_Pippettes_Locations_Location_Id",
                        column: x => x.Location_Id,
                        principalTable: "Locations",
                        principalColumn: "Location_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pippettes_Manufactures_Manufacture_Id",
                        column: x => x.Manufacture_Id,
                        principalTable: "Manufactures",
                        principalColumn: "Manufacture_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pippettes_PippetteUsers_Pippette_User_Id",
                        column: x => x.Pippette_User_Id,
                        principalTable: "PippetteUsers",
                        principalColumn: "Pippette_User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pippettes_Location_Id",
                table: "Pippettes",
                column: "Location_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pippettes_Manufacture_Id",
                table: "Pippettes",
                column: "Manufacture_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pippettes_Pippette_User_Id",
                table: "Pippettes",
                column: "Pippette_User_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Pippettes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Manufactures");

            migrationBuilder.DropTable(
                name: "PippetteUsers");
        }
    }
}
