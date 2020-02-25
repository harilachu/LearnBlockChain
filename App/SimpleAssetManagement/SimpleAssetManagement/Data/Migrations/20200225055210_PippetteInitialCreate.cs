using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleAssetManagement.Data.Migrations
{
    public partial class PippetteInitialCreate : Migration
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

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Location_Id", "Location_Name" },
                values: new object[,]
                {
                    { new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"), "R&D" },
                    { new Guid("696a03e9-ae8d-46a5-918f-2e4c19cecfd3"), "LAB" }
                });

            migrationBuilder.InsertData(
                table: "Manufactures",
                columns: new[] { "Manufacture_Id", "Manufacture_Name" },
                values: new object[,]
                {
                    { new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"), "RAININ" },
                    { new Guid("33e11f97-1705-466f-8f9d-9773d33aed8f"), "METTLER TOLEDO" }
                });

            migrationBuilder.InsertData(
                table: "PippetteUsers",
                columns: new[] { "Pippette_User_Id", "Pippette_User_Name" },
                values: new object[,]
                {
                    { new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"), "Alex" },
                    { new Guid("293d98bb-420b-4416-b5f0-7f6647e4548f"), "Joe" }
                });

            migrationBuilder.InsertData(
                table: "Pippettes",
                columns: new[] { "Pippette_Id", "Location_Id", "Manufacture_Id", "ModelName", "Pippette_User_Id", "SerialNumber", "UsageFrequency" },
                values: new object[] { new Guid("af5fe0c7-4a58-46e6-90c9-2feaf7238c90"), new Guid("696a03e9-ae8d-46a5-918f-2e4c19cecfd3"), new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"), "P2019", new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"), "P2019-MAR", 510 });

            migrationBuilder.InsertData(
                table: "Pippettes",
                columns: new[] { "Pippette_Id", "Location_Id", "Manufacture_Id", "ModelName", "Pippette_User_Id", "SerialNumber", "UsageFrequency" },
                values: new object[] { new Guid("32841a73-7cae-43c1-8f17-b17711de6caf"), new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"), new Guid("33e11f97-1705-466f-8f9d-9773d33aed8f"), "L2019", new Guid("293d98bb-420b-4416-b5f0-7f6647e4548f"), "L2019-FEB", 320 });

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
