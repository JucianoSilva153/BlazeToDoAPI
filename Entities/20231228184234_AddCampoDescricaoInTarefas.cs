using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazeToDo_API.Entities
{
    /// <inheritdoc />
    public partial class AddCampoDescricaoInTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Tarefa",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_bin")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Tarefa");
        }
    }
}
