using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstMigrationUpdates.Migrations
{
    public partial class Seed_Shelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shelf",
                columns: new[] { "ID", "Name", "ShelfMaterialID" },
                values: new object[,]
                {
                    { -1, "Book", -3 },
                    { -2, "Storage", -1 },
                    { -3, "Kitchen", -2 },
                    { -4, "Wardrobe", -4 },
                    { -5, "Closet", -3 },
                    { -6, "Study", -5 },
                    { -7, "MusicRoom", -4 },
                    { -8, "Workout", -1 },
                    { -9, "Outdoor", -2 },
                    { -10, "Washroom", -5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Shelf",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
