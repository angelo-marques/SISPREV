using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AddDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameTable(
                name: "SolicitacaoCompra",
                newName: "SolicitaCompra");

            migrationBuilder.AddColumn<int>(
                name: "NomeFornecedorId",
                table: "SolicitaCompra",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioSolicitanteId",
                table: "SolicitaCompra",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitaCompra",
                table: "SolicitaCompra",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NomeFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomeFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSolicitante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSolicitante", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Situacao" },
                values: new object[] { new Guid("810f9e94-2df9-4aef-9932-e68d9b9fb2bf"), 1, "Descricao01", "Produto01", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitaCompra_NomeFornecedorId",
                table: "SolicitaCompra",
                column: "NomeFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitaCompra_UsuarioSolicitanteId",
                table: "SolicitaCompra",
                column: "UsuarioSolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SolicitaCompra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitaCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitaCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitaCompra",
                column: "NomeFornecedorId",
                principalTable: "NomeFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitaCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitaCompra",
                column: "UsuarioSolicitanteId",
                principalTable: "UsuarioSolicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_SolicitaCompra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitaCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitaCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitaCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitaCompra");

            migrationBuilder.DropTable(
                name: "NomeFornecedor");

            migrationBuilder.DropTable(
                name: "UsuarioSolicitante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitaCompra",
                table: "SolicitaCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitaCompra_NomeFornecedorId",
                table: "SolicitaCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitaCompra_UsuarioSolicitanteId",
                table: "SolicitaCompra");

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("810f9e94-2df9-4aef-9932-e68d9b9fb2bf"));

            migrationBuilder.DropColumn(
                name: "NomeFornecedorId",
                table: "SolicitaCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitanteId",
                table: "SolicitaCompra");

            migrationBuilder.RenameTable(
                name: "SolicitaCompra",
                newName: "SolicitacaoCompra");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
