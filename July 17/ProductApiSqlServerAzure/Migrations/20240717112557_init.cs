using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApiSqlServerAzure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductImage", "ProductName", "ProductPrice" },
                values: new object[] { 101, "#", "Laptop", 500000.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductImage", "ProductName", "ProductPrice" },
                values: new object[] { 102, "#", "Laptop", 500000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
