using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTOMVC.Migrations
{
    public partial class hgghaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OS_Cliente_ClienteCNPJ",
                table: "OS");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_PrestadorServico_PrestadorServicoCPF",
                table: "OS");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_Servico_ServicoTitulo",
                table: "OS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servico",
                table: "Servico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrestadorServico",
                table: "PrestadorServico");

            migrationBuilder.DropIndex(
                name: "IX_OS_ClienteCNPJ",
                table: "OS");

            migrationBuilder.DropIndex(
                name: "IX_OS_PrestadorServicoCPF",
                table: "OS");

            migrationBuilder.DropIndex(
                name: "IX_OS_ServicoTitulo",
                table: "OS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ClienteCNPJ",
                table: "OS");

            migrationBuilder.DropColumn(
                name: "PrestadorServicoCPF",
                table: "OS");

            migrationBuilder.DropColumn(
                name: "ServicoTitulo",
                table: "OS");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Servico",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Servico",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "PrestadorServico",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PrestadorServico",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cliente",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servico",
                table: "Servico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrestadorServico",
                table: "PrestadorServico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OS_ClienteId",
                table: "OS",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OS_PrestadorServicoId",
                table: "OS",
                column: "PrestadorServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OS_ServicoId",
                table: "OS",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OS_Cliente_ClienteId",
                table: "OS",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OS_PrestadorServico_PrestadorServicoId",
                table: "OS",
                column: "PrestadorServicoId",
                principalTable: "PrestadorServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OS_Servico_ServicoId",
                table: "OS",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OS_Cliente_ClienteId",
                table: "OS");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_PrestadorServico_PrestadorServicoId",
                table: "OS");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_Servico_ServicoId",
                table: "OS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servico",
                table: "Servico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrestadorServico",
                table: "PrestadorServico");

            migrationBuilder.DropIndex(
                name: "IX_OS_ClienteId",
                table: "OS");

            migrationBuilder.DropIndex(
                name: "IX_OS_PrestadorServicoId",
                table: "OS");

            migrationBuilder.DropIndex(
                name: "IX_OS_ServicoId",
                table: "OS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PrestadorServico");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Servico",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "PrestadorServico",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ClienteCNPJ",
                table: "OS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrestadorServicoCPF",
                table: "OS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicoTitulo",
                table: "OS",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servico",
                table: "Servico",
                column: "Titulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrestadorServico",
                table: "PrestadorServico",
                column: "CPF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_OS_ClienteCNPJ",
                table: "OS",
                column: "ClienteCNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_OS_PrestadorServicoCPF",
                table: "OS",
                column: "PrestadorServicoCPF");

            migrationBuilder.CreateIndex(
                name: "IX_OS_ServicoTitulo",
                table: "OS",
                column: "ServicoTitulo");

            migrationBuilder.AddForeignKey(
                name: "FK_OS_Cliente_ClienteCNPJ",
                table: "OS",
                column: "ClienteCNPJ",
                principalTable: "Cliente",
                principalColumn: "CNPJ",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OS_PrestadorServico_PrestadorServicoCPF",
                table: "OS",
                column: "PrestadorServicoCPF",
                principalTable: "PrestadorServico",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OS_Servico_ServicoTitulo",
                table: "OS",
                column: "ServicoTitulo",
                principalTable: "Servico",
                principalColumn: "Titulo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
