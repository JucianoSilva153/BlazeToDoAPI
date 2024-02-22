namespace BlazeToDo_API.ToDo.DTO;

public class TarefasDeUmaListaDTO
{
    public string Lista { get; set; }
    public List<ListaTarefaDTO> Tarefas { get; set; }
}

public class ListaAlteraListaTarefaDTO
{
    public int Id { get; set; }
    public string Lista { get; set; }
}

public class CriaListaTarefasDTO
{
    public string Lista { get; set; }
    public int ContaID { get; set; }
}