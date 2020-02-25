using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleAssetManagement.Data.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Location_Id", "Location_Name" },
                values: new object[] { new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"), "R&D" });

            migrationBuilder.InsertData(
                table: "Manufactures",
                columns: new[] { "Manufacture_Id", "Manufacture_Name" },
                values: new object[] { new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"), "RAININ" });

            migrationBuilder.InsertData(
                table: "PippetteUsers",
                columns: new[] { "Pippette_User_Id", "Pippette_User_Name" },
                values: new object[] { new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"), "Alex" });

            migrationBuilder.InsertData(
                table: "Pippettes",
                columns: new[] { "Pippette_Id", "Location_Id", "Manufacture_Id", "ModelName", "Pippette_User_Id", "SerialNumber", "UsageFrequency" },
                values: new object[] { new Guid("e4efebe7-995c-4560-b99a-efa5bd75ecb7"), new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"), new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"), "P2020", new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"), "P2020-FEB", 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pippettes",
                keyColumn: "Pippette_Id",
                keyValue: new Guid("e4efebe7-995c-4560-b99a-efa5bd75ecb7"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Location_Id",
                keyValue: new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"));

            migrationBuilder.DeleteData(
                table: "Manufactures",
                keyColumn: "Manufacture_Id",
                keyValue: new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"));

            migrationBuilder.DeleteData(
                table: "PippetteUsers",
                keyColumn: "Pippette_User_Id",
                keyValue: new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"));
        }
    }
}
