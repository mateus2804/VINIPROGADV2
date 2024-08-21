using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTOMVC.Migrations
{
    public partial class FirstChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OS_ProvedorServico_ProvedorServicoCPF",
                table: "OS");

            migrationBuilder.DropTable(
                name: "ProvedorServico");

            migrationBuilder.CreateTable(
                name: "PrestadorServico",
                columns: table => new
                {
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadorServico", x => x.CPF);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OS_PrestadorServico_ProvedorServicoCPF",
                table: "OS",
                column: "ProvedorServicoCPF",
                principalTable: "PrestadorServico",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OS_PrestadorServico_ProvedorServicoCPF",
                table: "OS");

            migrationBuilder.DropTable(
                name: "PrestadorServico");

            migrationBuilder.CreateTable(
                name: "ProvedorServico",
                columns: table => new
                {
                    CPF = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvedorServico", x => x.CPF);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OS_ProvedorServico_ProvedorServicoCPF",
                table: "OS",
                column: "ProvedorServicoCPF",
                principalTable: "ProvedorServico",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
