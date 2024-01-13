using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazeToDo_API.ToDo;

public class TarefaModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Prioridade { get; set; }
    public string? Descricao { get; set; }
    public string? DataConclusao { get; set; }
    public string? DataCriacao { get; set; }
    public bool Concluida { get; set; } = false;


    
    public int CategoriaId { get; set; }
    public CategoriaModel? Categoria { get; set; }

    public int ListaId { get; set; }
    
    public ListaModel? Lista { get; set; }
}