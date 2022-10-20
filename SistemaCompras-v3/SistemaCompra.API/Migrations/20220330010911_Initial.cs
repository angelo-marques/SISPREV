using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "SolicitaCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    UsuarioSolicitanteId = table.Column<int>(nullable: true),
                    NomeFornecedorId = table.Column<int>(nullable: true),
                    TotalGeral = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitaCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitaCompra_NomeFornecedor_NomeFornecedorId",
                        column: x => x.NomeFornecedorId,
                        principalTable: "NomeFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitaCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                        column: x => x.UsuarioSolicitanteId,
                        principalTable: "UsuarioSolicitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true),
                    Qtde = table.Column<int>(nullable: false),
                    SolicitacaoCompraId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_SolicitaCompra_SolicitacaoCompraId",
                        column: x => x.SolicitacaoCompraId,
                        principalTable: "SolicitaCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("99d07914-5474-4d47-85ab-d5b7c48b4b3e"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProdutoId",
                table: "Items",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SolicitacaoCompraId",
                table: "Items",
                column: "SolicitacaoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitaCompra_NomeFornecedorId",
                table: "SolicitaCompra",
                column: "NomeFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitaCompra_UsuarioSolicitanteId",
                table: "SolicitaCompra",
                column: "UsuarioSolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "SolicitaCompra");

            migrationBuilder.DropTable(
                name: "NomeFornecedor");

            migrationBuilder.DropTable(
                name: "UsuarioSolicitante");
        }
    }
}
