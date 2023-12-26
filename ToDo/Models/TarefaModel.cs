namespace BlazeToDo_API.ToDo;

public class TarefaModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Prioridade { get; set; }
    public CategoriaModel? Categoria  { get; set; }
    public string? DataConclusao { get; set; }
    public string? DataCriacao { get; set; }
    public bool Concluida { get; set; } = false;
}