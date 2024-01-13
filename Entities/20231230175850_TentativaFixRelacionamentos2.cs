using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazeToDo_API.Entities
{
    /// <inheritdoc />
    public partial class TentativaFixRelacionamentos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Lista_ListaModelId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_ListaModelId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "ListaModelId",
                table: "Tarefa");

            migrationBuilder.AddColumn<int>(
                name: "ListaId",
                table: "Tarefa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ListaId",
                table: "Tarefa",
                column: "ListaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Lista_ListaId",
                table: "Tarefa",
                column: "ListaId",
                principalTable: "Lista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Lista_ListaId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_ListaId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "ListaId",
                table: "Tarefa");

            migrationBuilder.AddColumn<int>(
                name: "ListaModelId",
                table: "Tarefa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ListaModelId",
                table: "Tarefa",
                column: "ListaModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Lista_ListaModelId",
                table: "Tarefa",
                column: "ListaModelId",
                principalTable: "Lista",
                principalColumn: "Id");
        }
    }
}
