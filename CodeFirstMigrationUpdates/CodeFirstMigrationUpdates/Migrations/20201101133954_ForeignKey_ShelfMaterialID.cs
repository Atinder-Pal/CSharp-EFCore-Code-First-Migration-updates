using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstMigrationUpdates.Migrations
{
    public partial class ForeignKey_ShelfMaterialID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ShelfMaterialID",
                table: "Shelf",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Shelf_Material",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaterialName = table.Column<string>(type: "varchar(25)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelf_Material", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "FK_Shelf_ShelfMaterial",
                table: "Shelf",
                column: "ShelfMaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelf_ShelfMaterial",
                table: "Shelf",
                column: "ShelfMaterialID",
                principalTable: "Shelf_Material",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelf_ShelfMaterial",
                table: "Shelf");

            migrationBuilder.DropTable(
                name: "Shelf_Material");

            migrationBuilder.DropIndex(
                name: "FK_Shelf_ShelfMaterial",
                table: "Shelf");

            migrationBuilder.DropColumn(
                name: "ShelfMaterialID",
                table: "Shelf");

            migrationBuilder.InsertData(
                table: "Shelf",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { -1, "Work" },
                    { -2, "Computer" },
                    { -3, "Kitchen" },
                    { -4, "DiningRoom" },
                    { -5, "BedRoom" }
                });
        }
    }
}
