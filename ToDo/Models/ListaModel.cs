namespace BlazeToDo_API.ToDo;

public class ListaModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<TarefaModel> Tarefas { get; set; }
}