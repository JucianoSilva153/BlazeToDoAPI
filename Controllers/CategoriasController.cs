using System.ComponentModel.DataAnnotations;
using BlazeToDo_API.ToDo;
using Microsoft.AspNetCore.Mvc;

namespace BlazeToDo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpPost]
        [Route("/nova")]
        public async Task<RequestResponse> CriarCategoria(Categorias categorias,
            [FromBody] CategoriaModel novaCategoria)
        {
            return await categorias.CreateCategoria(novaCategoria);
        }

        [HttpGet]
        [Route("/listar")]
        public async Task<RequestResponse> ListarTodasCategorias(Categorias categorias)
        {
            return await categorias.ListAllCategorias();
        }

        [HttpPut]
        [Route("/alterar")]
        public async Task<RequestResponse> AlterarCategoria(Categorias categorias, [FromBody] CategoriaModel categoria)
        {
            return await categorias.EditCategoria(categoria);
        }

        [HttpDelete]
        [Route("/apagar")]
        public async Task<RequestResponse> ApagarCategoria(Categorias categorias, [FromBody] CategoriaModel categoria)
        {
            return await categorias.DeleteCategoria(categoria);
        }
    }
}