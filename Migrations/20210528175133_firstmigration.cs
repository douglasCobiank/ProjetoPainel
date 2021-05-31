using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjetoPainel.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rpa_pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cargo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rpa_pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rpa_carteirapessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SuperId = table.Column<int>(type: "integer", nullable: true),
                    Id_executivo = table.Column<int>(type: "integer", nullable: false),
                    ExecutivoId = table.Column<int>(type: "integer", nullable: true),
                    Cod_carteira = table.Column<int>(type: "integer", nullable: false),
                    CoordenadorId = table.Column<int>(type: "integer", nullable: true),
                    BPId = table.Column<int>(type: "integer", nullable: true),
                    LiderTecnicoId = table.Column<int>(type: "integer", nullable: true),
                    ProgramadorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rpa_carteirapessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rpa_carteirapessoa_rpa_pessoa_BPId",
                        column: x => x.BPId,
                        principalTable: "rpa_pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rpa_carteirapessoa_rpa_pessoa_CoordenadorId",
                        column: x => x.CoordenadorId,
                        principalTable: "rpa_pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rpa_carteirapessoa_rpa_pessoa_ExecutivoId",
                        column: x => x.ExecutivoId,
                        principalTable: "rpa_pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rpa_carteirapessoa_rpa_pessoa_LiderTecnicoId",
                        column: x => x.LiderTecnicoId,
                        principalTable: "rpa_pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rpa_carteirapessoa_rpa_pessoa_ProgramadorId",
                        column: x => x.ProgramadorId,
                        principalTable: "rpa_pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rpa_carteirapessoa_rpa_pessoa_SuperId",
                        column: x => x.SuperId,
                        principalTable: "rpa_pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rpa_carteirapessoa_BPId",
                table: "rpa_carteirapessoa",
                column: "BPId");

            migrationBuilder.CreateIndex(
                name: "IX_rpa_carteirapessoa_CoordenadorId",
                table: "rpa_carteirapessoa",
                column: "CoordenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_rpa_carteirapessoa_ExecutivoId",
                table: "rpa_carteirapessoa",
                column: "ExecutivoId");

            migrationBuilder.CreateIndex(
                name: "IX_rpa_carteirapessoa_LiderTecnicoId",
                table: "rpa_carteirapessoa",
                column: "LiderTecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_rpa_carteirapessoa_ProgramadorId",
                table: "rpa_carteirapessoa",
                column: "ProgramadorId");

            migrationBuilder.CreateIndex(
                name: "IX_rpa_carteirapessoa_SuperId",
                table: "rpa_carteirapessoa",
                column: "SuperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rpa_carteirapessoa");

            migrationBuilder.DropTable(
                name: "rpa_pessoa");
        }
    }
}
