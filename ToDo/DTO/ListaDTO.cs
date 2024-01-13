namespace BlazeToDo_API.ToDo.DTO;

public class TarefasDeUmaListaDTO
{
    public string Lista { get; set; }
    public List<ListaTarefaDTO> Tarefas { get; set; }
}

public class ListaAlteraListaTarefa
{
    public int Id { get; set; }
    public string Lista { get; set; }
}