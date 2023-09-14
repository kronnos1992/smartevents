using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gesteventos.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ProjectOnLayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Local = table.Column<string>(type: "TEXT", nullable: true),
                    Tema = table.Column<string>(type: "TEXT", nullable: true),
                    EventoData = table.Column<DateTime>(type: "TEXT", nullable: true),
                    QtdPessoas = table.Column<int>(type: "INTEGER", nullable: false),
                    Lote = table.Column<string>(type: "TEXT", nullable: true),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Palestrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: true),
                    MiniCv = table.Column<string>(type: "TEXT", nullable: true),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Palestrantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Lotes_Tb_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Tb_Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_EventoPalestrantes",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PalestranteId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_EventoPalestrantes", x => new { x.EventoId, x.PalestranteId });
                    table.ForeignKey(
                        name: "FK_Tb_EventoPalestrantes_Tb_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Tb_Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_EventoPalestrantes_Tb_Palestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "Tb_Palestrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_RedeSociais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: true),
                    PalestranteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_RedeSociais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_RedeSociais_Tb_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Tb_Eventos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tb_RedeSociais_Tb_Palestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "Tb_Palestrantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_EventoPalestrantes_PalestranteId",
                table: "Tb_EventoPalestrantes",
                column: "PalestranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Lotes_EventoId",
                table: "Tb_Lotes",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RedeSociais_EventoId",
                table: "Tb_RedeSociais",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RedeSociais_PalestranteId",
                table: "Tb_RedeSociais",
                column: "PalestranteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_EventoPalestrantes");

            migrationBuilder.DropTable(
                name: "Tb_Lotes");

            migrationBuilder.DropTable(
                name: "Tb_RedeSociais");

            migrationBuilder.DropTable(
                name: "Tb_Eventos");

            migrationBuilder.DropTable(
                name: "Tb_Palestrantes");
        }
    }
}
