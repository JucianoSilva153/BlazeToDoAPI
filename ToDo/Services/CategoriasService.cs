using BlazeToDo_API.Context;
using Microsoft.EntityFrameworkCore;

namespace BlazeToDo_API.ToDo.Services;

public class CategoriasService
{
    private DBToDO acessoDados = new DBToDO();

    public async Task<RequestResponse> CreateCategoria(CategoriaModel categoria)
    {
        try
        {
            acessoDados.Categoria.Add(categoria);
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
            Mensagem = "Categoria Adicionada com sucesso!!",
            Sucesso = true
        };
    }

    public async Task<RequestResponse> ListAllCategorias()
    {
        var categorias = new List<CategoriaModel>();
        try
        {
            categorias = await acessoDados.Categoria.AsNoTracking()
                .Include(c => c.Tarefas)
                .ToListAsync();

            foreach (var categoria in categorias)
            {
                foreach (var tarefa in categoria.Tarefas)
                {
                    tarefa.Categoria = null;
                }
            }
        }
        catch (Exception e)
        {
            return new RequestResponse
            {
                Sucesso = false,
                Mensagem = e.Message
            };
        }

        return new RequestResponse
        {
            Mensagem = "Lista de Categorias Retornada com Sucesso!",
            Sucesso = true,
            Target = categorias
        };
    }

    public async Task<RequestResponse> EditCategoria(CategoriaModel categoria)
    {
        var categoriaAlterar = new CategoriaModel();
        try
        {
            categoriaAlterar = await acessoDados.Categoria.FirstAsync(e => e.Id == categoria.Id);
            categoriaAlterar.Nome = categoria.Nome;
            acessoDados.Update(categoriaAlterar);
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
            Mensagem = "Categoria alterada com sucesso!",
            Sucesso = true,
            Target = categoriaAlterar
        };
    }

    public async Task<RequestResponse> DeleteCategoria(CategoriaModel categoria)
    {
        try
        {
            acessoDados.Remove(categoria);
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
            Mensagem = "Categoria Eliminada com sucesso!!",
            Sucesso = true,
            Target = categoria
        };
    }
}