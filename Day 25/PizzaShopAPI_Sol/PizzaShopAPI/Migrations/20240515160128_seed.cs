using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaShopAPI.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PId", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 101, "Spicy With Loaded Cheese", "Chilli Cheese Pizza", 100, 10 });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PId", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 102, "Panner With Loaded Cheese", "Panner Cheese Pizza", 200, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PId",
                keyValue: 102);
        }
    }
}
