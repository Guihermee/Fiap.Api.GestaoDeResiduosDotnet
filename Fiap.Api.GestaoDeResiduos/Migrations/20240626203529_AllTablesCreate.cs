using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.GestaoDeResiduos.Migrations
{
    /// <inheritdoc />
    public partial class AllTablesCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ATERRO",
                columns: table => new
                {
                    ID_ATERRO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QTD_ATUAL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QTD_ATERRO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NM_LOCALIZACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ST_CAPACIDADE = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ATERRO", x => x.ID_ATERRO);
                });

            migrationBuilder.CreateTable(
                name: "T_CAMINHAO",
                columns: table => new
                {
                    ID_CAMINHAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QTD_ATUAL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VL_CAPACIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NM_LOCALIZACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CAMINHAO", x => x.ID_CAMINHAO);
                });

            migrationBuilder.CreateTable(
                name: "T_COLETA",
                columns: table => new
                {
                    ID_COLETA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ST_COLETA = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NM_LOCALIZACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    T_CAMINHAO_ID_CAMINHAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_COLETA", x => x.ID_COLETA);
                    table.ForeignKey(
                        name: "FK_T_COLETA_T_CAMINHAO_T_CAMINHAO_ID_CAMINHAO",
                        column: x => x.T_CAMINHAO_ID_CAMINHAO,
                        principalTable: "T_CAMINHAO",
                        principalColumn: "ID_CAMINHAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_FUNCIONARIO",
                columns: table => new
                {
                    ID_FUNCIONARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_FUNCIONARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NM_FUNCAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NM_DEPT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    T_CAMINHAO_ID_CAMINHAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_FUNCIONARIO", x => x.ID_FUNCIONARIO);
                    table.ForeignKey(
                        name: "FK_T_FUNCIONARIO_T_CAMINHAO_T_CAMINHAO_ID_CAMINHAO",
                        column: x => x.T_CAMINHAO_ID_CAMINHAO,
                        principalTable: "T_CAMINHAO",
                        principalColumn: "ID_CAMINHAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ROTA",
                columns: table => new
                {
                    ID_ROTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    T_CAMINHAO_ID_CAMINHAO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    T_ATERRO_ID_ATERRO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ROTA", x => x.ID_ROTA);
                    table.ForeignKey(
                        name: "FK_T_ROTA_T_ATERRO_T_ATERRO_ID_ATERRO",
                        column: x => x.T_ATERRO_ID_ATERRO,
                        principalTable: "T_ATERRO",
                        principalColumn: "ID_ATERRO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_ROTA_T_CAMINHAO_T_CAMINHAO_ID_CAMINHAO",
                        column: x => x.T_CAMINHAO_ID_CAMINHAO,
                        principalTable: "T_CAMINHAO",
                        principalColumn: "ID_CAMINHAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_COLETA_T_CAMINHAO_ID_CAMINHAO",
                table: "T_COLETA",
                column: "T_CAMINHAO_ID_CAMINHAO");

            migrationBuilder.CreateIndex(
                name: "IX_T_FUNCIONARIO_T_CAMINHAO_ID_CAMINHAO",
                table: "T_FUNCIONARIO",
                column: "T_CAMINHAO_ID_CAMINHAO");

            migrationBuilder.CreateIndex(
                name: "IX_T_ROTA_T_ATERRO_ID_ATERRO",
                table: "T_ROTA",
                column: "T_ATERRO_ID_ATERRO");

            migrationBuilder.CreateIndex(
                name: "IX_T_ROTA_T_CAMINHAO_ID_CAMINHAO",
                table: "T_ROTA",
                column: "T_CAMINHAO_ID_CAMINHAO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_COLETA");

            migrationBuilder.DropTable(
                name: "T_FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "T_ROTA");

            migrationBuilder.DropTable(
                name: "T_ATERRO");

            migrationBuilder.DropTable(
                name: "T_CAMINHAO");
        }
    }
}
