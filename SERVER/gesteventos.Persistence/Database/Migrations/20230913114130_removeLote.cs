using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gesteventos.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class removeLote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lote",
                table: "Tb_Eventos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lote",
                table: "Tb_Eventos",
                type: "TEXT",
                nullable: true);
        }
    }
}
