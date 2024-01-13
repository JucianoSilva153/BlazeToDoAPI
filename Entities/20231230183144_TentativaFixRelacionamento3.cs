using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazeToDo_API.Entities
{
    /// <inheritdoc />
    public partial class TentativaFixRelacionamento3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Categoria_CategoriaId",
                table: "Tarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Lista_ListaId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_ListaId",
                table: "Tarefa");

            migrationBuilder.AddColumn<int>(
                name: "TarefasId",
                table: "Lista",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lista_TarefasId",
                table: "Lista",
                column: "TarefasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lista_Tarefa_TarefasId",
                table: "Lista",
                column: "TarefasId",
                principalTable: "Tarefa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Categoria_CategoriaId",
                table: "Tarefa",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lista_Tarefa_TarefasId",
                table: "Lista");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Categoria_CategoriaId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Lista_TarefasId",
                table: "Lista");

            migrationBuilder.DropColumn(
                name: "TarefasId",
                table: "Lista");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ListaId",
                table: "Tarefa",
                column: "ListaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Categoria_CategoriaId",
                table: "Tarefa",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Lista_ListaId",
                table: "Tarefa",
                column: "ListaId",
                principalTable: "Lista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
