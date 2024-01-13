using BlazeToDo_API.Context;
using Microsoft.EntityFrameworkCore;

namespace BlazeToDo_API.ToDo.Services;

public class ListasService
{
    private DBToDO acessoDados = new DBToDO();
    public async Task<RequestResponse> CreateTaskList(ListaModel lista)
    {
        try
        {
            acessoDados.Lista.Add(lista);
            await acessoDados.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return new RequestResponse
            {
                Mensagem = e.Message,
                Sucesso = false
            };
        }

        return new RequestResponse
        {
            Mensagem = "Lista de tarefas adicionada com sucesso!",
            Sucesso = true,
            Target = lista
        };
    }

    public async Task<RequestResponse> ListTaskList()
    {
        var listasTarefa = new List<ListaModel>();
        try
        {
            listasTarefa = await acessoDados.Lista
                .AsNoTracking()
                .Include(c => c.Tarefas)
                .ToListAsync();

            foreach (var lista in listasTarefa)
            {
                foreach (var tarefa in lista.Tarefas)
                {
                    tarefa.Lista = null;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new RequestResponse
        {
            Mensagem = "Listas de tarefas listadas com sucesso",
            Sucesso = true,
            Target = listasTarefa
        };
    }
}