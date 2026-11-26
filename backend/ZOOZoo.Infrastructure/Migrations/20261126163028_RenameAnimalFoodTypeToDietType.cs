using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZOOZoo.Migrations
{
    /// <inheritdoc />
    public partial class RenameAnimalFoodTypeToDietType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodType",
                table: "Animals",
                newName: "DietType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DietType",
                table: "Animals",
                newName: "FoodType");
        }
    }
}
