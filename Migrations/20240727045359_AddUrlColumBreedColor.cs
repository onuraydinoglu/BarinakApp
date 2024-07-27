using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barinak.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlColumBreedColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Breeds",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Breeds");
        }
    }
}
