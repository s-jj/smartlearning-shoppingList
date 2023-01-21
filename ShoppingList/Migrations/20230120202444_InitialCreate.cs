using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopItemModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ShopItemModel",
                columns: new[] { "Id", "Name", "Quantity", "Section", "Unit" },
                values: new object[,]
                {
                    { 1, "Shop item 1", 5, 1, 1 },
                    { 2, "Shop item 2", 2, 4, 2 },
                    { 3, "Shop item 3", 1, 5, 2 },
                    { 4, "Shop item 4", 100, 2, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopItemModel");
        }
    }
}
