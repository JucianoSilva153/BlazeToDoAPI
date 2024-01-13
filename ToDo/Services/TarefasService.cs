using BlazeToDo_API.Context;
using Microsoft.EntityFrameworkCore;

namespace BlazeToDo_API.ToDo.Services;

public class TarefasService
{
    private DBToDO acessoDados = new DBToDO();


    public async Task<RequestResponse> CreateTask(TarefaModel tarefa)
    {
        try
        {
            var categoriaNovaTarefa = await acessoDados.Categoria.FirstAsync(c => c.Id == tarefa.CategoriaId);
            var listaNovaTarefa = await acessoDados.Lista.FirstOrDefaultAsync(l => l.Id == tarefa.ListaId);

            await acessoDados.Tarefa.AddAsync(new TarefaModel
            {
                Nome = tarefa.Nome,
                Categoria = categoriaNovaTarefa,
                Concluida = false,
                Descricao = tarefa.Descricao,
                Lista = listaNovaTarefa,
                Prioridade = tarefa.Prioridade,
                CategoriaId = categoriaNovaTarefa.Id,
                DataConclusao = tarefa.DataConclusao,
                DataCriacao = tarefa.DataCriacao,
                ListaId = listaNovaTarefa is null ? 0 : listaNovaTarefa.Id
            });
            await acessoDados.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw;
        }

        return new RequestResponse
        {
            Mensagem = "Tarefa Adicionada Com sucesso",
            Sucesso = true,
            Target = null
        };
    }

    public async Task<RequestResponse> ListTasks()
    {
        var listaTarefa = new List<TarefaModel>();
        try
        {
            listaTarefa = await acessoDados.Tarefa.AsNoTracking()
                .Include(t => t.Categoria)
                .ToListAsync();

            foreach (var tarefa in listaTarefa)
            {
                tarefa.Categoria.Tarefas = null;
            }
        }
        catch (Exception e)
        {
            throw;
        }

        return new RequestResponse
        {
            Mensagem = "Lista de Tarefas Retornada com sucesso!",
            Sucesso = true,
            Target = listaTarefa
        };
    }
}