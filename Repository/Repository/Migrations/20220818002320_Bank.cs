using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class Bank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_cuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo_cuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saldo_inicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado_cuenta = table.Column<bool>(type: "bit", nullable: false),
                    cliente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado_cliente = table.Column<bool>(type: "bit", nullable: false),
                    identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personaid = table.Column<int>(type: "int", nullable: true),
                    Cuentaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cliente_Cuenta_Cuentaid",
                        column: x => x.Cuentaid,
                        principalTable: "Cuenta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Persona_Personaid",
                        column: x => x.Personaid,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cuentaid",
                table: "Cliente",
                column: "Cuentaid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Personaid",
                table: "Cliente",
                column: "Personaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
