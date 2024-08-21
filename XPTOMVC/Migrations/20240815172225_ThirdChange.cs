using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTOMVC.Migrations
{
    public partial class ThirdChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OS");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "PrestadorServico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CNPJ = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CNPJ);
                });

            migrationBuilder.CreateTable(
                name: "PrestadorServico",
                columns: table => new
                {
                    CPF = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadorServico", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "OS",
                columns: table => new
                {
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteCNPJ = table.Column<string>(nullable: true),
                    DataExecucao = table.Column<DateTime>(nullable: false),
                    ProvedorServicoCPF = table.Column<string>(nullable: true),
                    ServicoTitulo = table.Column<string>(nullable: true),
                    ValorServico = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OS", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_OS_Cliente_ClienteCNPJ",
                        column: x => x.ClienteCNPJ,
                        principalTable: "Cliente",
                        principalColumn: "CNPJ",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OS_PrestadorServico_ProvedorServicoCPF",
                        column: x => x.ProvedorServicoCPF,
                        principalTable: "PrestadorServico",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OS_Servico_ServicoTitulo",
                        column: x => x.ServicoTitulo,
                        principalTable: "Servico",
                        principalColumn: "Titulo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OS_ClienteCNPJ",
                table: "OS",
                column: "ClienteCNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_OS_ProvedorServicoCPF",
                table: "OS",
                column: "ProvedorServicoCPF");

            migrationBuilder.CreateIndex(
                name: "IX_OS_ServicoTitulo",
                table: "OS",
                column: "ServicoTitulo");
        }
    }
}
