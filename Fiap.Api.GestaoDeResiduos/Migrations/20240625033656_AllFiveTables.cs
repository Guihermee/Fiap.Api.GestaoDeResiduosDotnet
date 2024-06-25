using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.GestaoDeResiduos.Migrations
{
    /// <inheritdoc />
    public partial class AllFiveTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caminhao",
                columns: table => new
                {
                    IdCaminhao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QtdAtual = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VlCapacidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NmLocalizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhao", x => x.IdCaminhao);
                });

            migrationBuilder.CreateTable(
                name: "Coleta",
                columns: table => new
                {
                    IdColeta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StColeta = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NmLocalizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdCaminhao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coleta", x => x.IdColeta);
                    table.ForeignKey(
                        name: "FK_Coleta_Caminhao_IdCaminhao",
                        column: x => x.IdCaminhao,
                        principalTable: "Caminhao",
                        principalColumn: "IdCaminhao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmFuncionario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NmFuncao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NmDept = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdCaminhao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "FK_Funcionario_Caminhao_IdCaminhao",
                        column: x => x.IdCaminhao,
                        principalTable: "Caminhao",
                        principalColumn: "IdCaminhao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    IdRota = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdCaminhao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdAterro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.IdRota);
                    table.ForeignKey(
                        name: "FK_Rota_Caminhao_IdCaminhao",
                        column: x => x.IdCaminhao,
                        principalTable: "Caminhao",
                        principalColumn: "IdCaminhao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aterro",
                columns: table => new
                {
                    IdAterro = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QqtdAtual = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QtdAterro = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NmLocalizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StCapacidade = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aterro", x => x.IdAterro);
                    table.ForeignKey(
                        name: "FK_Aterro_Rota_IdAterro",
                        column: x => x.IdAterro,
                        principalTable: "Rota",
                        principalColumn: "IdRota",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_IdCaminhao",
                table: "Coleta",
                column: "IdCaminhao");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdCaminhao",
                table: "Funcionario",
                column: "IdCaminhao");

            migrationBuilder.CreateIndex(
                name: "IX_Rota_IdCaminhao",
                table: "Rota",
                column: "IdCaminhao",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aterro");

            migrationBuilder.DropTable(
                name: "Coleta");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Rota");

            migrationBuilder.DropTable(
                name: "Caminhao");
        }
    }
}
