using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Midioteca.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoMidiaToMidia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoMidia",
                table: "Midias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMidia",
                table: "Midias");
        }
    }
}
