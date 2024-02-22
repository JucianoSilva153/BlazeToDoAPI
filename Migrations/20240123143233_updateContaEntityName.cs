using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazeToDo_API.Migrations
{
    /// <inheritdoc />
    public partial class updateContaEntityName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_ContaModel_ContaId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Lista_ContaModel_ContaId",
                table: "Lista");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_ContaModel_ContaId",
                table: "Tarefa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContaModel",
                table: "ContaModel");

            migrationBuilder.RenameTable(
                name: "ContaModel",
                newName: "Conta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conta",
                table: "Conta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Conta_ContaId",
                table: "Categoria",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lista_Conta_ContaId",
                table: "Lista",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Conta_ContaId",
                table: "Tarefa",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Conta_ContaId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Lista_Conta_ContaId",
                table: "Lista");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Conta_ContaId",
                table: "Tarefa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conta",
                table: "Conta");

            migrationBuilder.RenameTable(
                name: "Conta",
                newName: "ContaModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContaModel",
                table: "ContaModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_ContaModel_ContaId",
                table: "Categoria",
                column: "ContaId",
                principalTable: "ContaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lista_ContaModel_ContaId",
                table: "Lista",
                column: "ContaId",
                principalTable: "ContaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_ContaModel_ContaId",
                table: "Tarefa",
                column: "ContaId",
                principalTable: "ContaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
