using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.GestaoDeResiduos.Migrations
{
    /// <inheritdoc />
    public partial class UserTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_USER",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USERNAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PASSWORD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ROLE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true, defaultValue: "operador")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER", x => x.ID_USER);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_USER");
        }
    }
}
