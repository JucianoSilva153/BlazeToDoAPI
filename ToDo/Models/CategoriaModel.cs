namespace BlazeToDo_API.ToDo;

public class CategoriaModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ICollection<TarefaModel>? Tarefas { get; set; }
}