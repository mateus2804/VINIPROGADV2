using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTOMVC.Migrations
{
    public partial class hggha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OS_PrestadorServico_ProvedorServicoCPF",
                table: "OS");

            migrationBuilder.RenameColumn(
                name: "ProvedorServicoCPF",
                table: "OS",
                newName: "PrestadorServicoCPF");

            migrationBuilder.RenameIndex(
                name: "IX_OS_ProvedorServicoCPF",
                table: "OS",
                newName: "IX_OS_PrestadorServicoCPF");

            migrationBuilder.AddForeignKey(
                name: "FK_OS_PrestadorServico_PrestadorServicoCPF",
                table: "OS",
                column: "PrestadorServicoCPF",
                principalTable: "PrestadorServico",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OS_PrestadorServico_PrestadorServicoCPF",
                table: "OS");

            migrationBuilder.RenameColumn(
                name: "PrestadorServicoCPF",
                table: "OS",
                newName: "ProvedorServicoCPF");

            migrationBuilder.RenameIndex(
                name: "IX_OS_PrestadorServicoCPF",
                table: "OS",
                newName: "IX_OS_ProvedorServicoCPF");

            migrationBuilder.AddForeignKey(
                name: "FK_OS_PrestadorServico_ProvedorServicoCPF",
                table: "OS",
                column: "ProvedorServicoCPF",
                principalTable: "PrestadorServico",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
