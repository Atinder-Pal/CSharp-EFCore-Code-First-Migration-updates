using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstMigrationUpdates.Migrations
{
    public partial class Seed_ShelfMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shelf_Material",
                columns: new[] { "ID", "MaterialName" },
                values: new object[,]
                {
                    { -1, "Concrete" },
                    { -2, "Marble" },
                    { -3, "Rock" },
                    { -4, "Ceramic" },
                    { -5, "Plastic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shelf_Material",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Shelf_Material",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Shelf_Material",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Shelf_Material",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Shelf_Material",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
