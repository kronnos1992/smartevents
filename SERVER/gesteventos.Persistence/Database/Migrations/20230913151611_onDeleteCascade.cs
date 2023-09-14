using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gesteventos.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class onDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_RedeSociais_Tb_Eventos_EventoId",
                table: "Tb_RedeSociais");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_RedeSociais_Tb_Palestrantes_PalestranteId",
                table: "Tb_RedeSociais");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_RedeSociais_Tb_Eventos_EventoId",
                table: "Tb_RedeSociais",
                column: "EventoId",
                principalTable: "Tb_Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_RedeSociais_Tb_Palestrantes_PalestranteId",
                table: "Tb_RedeSociais",
                column: "PalestranteId",
                principalTable: "Tb_Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_RedeSociais_Tb_Eventos_EventoId",
                table: "Tb_RedeSociais");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_RedeSociais_Tb_Palestrantes_PalestranteId",
                table: "Tb_RedeSociais");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_RedeSociais_Tb_Eventos_EventoId",
                table: "Tb_RedeSociais",
                column: "EventoId",
                principalTable: "Tb_Eventos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_RedeSociais_Tb_Palestrantes_PalestranteId",
                table: "Tb_RedeSociais",
                column: "PalestranteId",
                principalTable: "Tb_Palestrantes",
                principalColumn: "Id");
        }
    }
}
