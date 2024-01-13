using BlazeToDo_API.Context;
using BlazeToDo_API.ToDo.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlazeToDo_API.ToDo.Services;

public class CategoriasService
{
    private DBToDO acessoDados = new DBToDO();

    public async Task<RequestResponse> CreateCategoria(CriaCategoriaDTO categoria)
    {
        var retornoCategoria = new CriaCategoriaDTO();
        try
        {
            var novaCategoria = new CategoriaModel
            {
                Nome = categoria.Categoria
            };

            var categoriaAdicionada = acessoDados.Categoria.Add(novaCategoria);
            await acessoDados.SaveChangesAsync();

            retornoCategoria = new CriaCategoriaDTO
            {
                Categoria = categoriaAdicionada.Entity.Nome
            };
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
            Sucesso = true,
            Target = retornoCategoria
        };
    }

    public async Task<RequestResponse> ListAllCategorias()
    {
        var categorias = new List<CriaCategoriaDTO>();
        try
        {
            var ListaCategorias = await acessoDados.Categoria.AsNoTracking()
                .Include(c => c.Tarefas)
                .ToListAsync();

            foreach (var categoria in ListaCategorias)
            {
                categorias.Add(new CriaCategoriaDTO
                {
                    Categoria = categoria.Nome
                });
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

    public async Task<RequestResponse> EditCategoria(ListaAlteraCategorias categoria)
    {
        var categoriaAlterar = new CategoriaModel();
        try
        {
            categoriaAlterar = await acessoDados.Categoria.FirstAsync(e => e.Id == categoria.Id);
            categoriaAlterar.Nome = categoria.Categoria;
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
            Target = categoria
        };
    }

    public async Task<RequestResponse> DeleteCategoria(int IdCategoria)
    {
        try
        {
            var categoriaRemover = await acessoDados.Categoria
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == IdCategoria);

            if (categoriaRemover is null)
                return new RequestResponse
                {
                    Mensagem = "Categoria Nao encontrada",
                    Sucesso = false
                };
            
            acessoDados.Remove<CategoriaModel>(categoriaRemover);
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
            Sucesso = true
        };
    }
}