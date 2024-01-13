using System.ComponentModel.DataAnnotations;
using BlazeToDo_API.ToDo;
using BlazeToDo_API.ToDo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazeToDo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriasService service;
        public CategoriasController(CategoriasService _service)
        {
            service = _service;
        }
        
        [HttpPost]
        public async Task<RequestResponse> CriarCategoria( [FromBody] CategoriaModel novaCategoria)
        {
            return await service.CreateCategoria(novaCategoria);
        }

        [HttpGet]
        public async Task<RequestResponse> ListarTodasCategorias()
        {
            return await service.ListAllCategorias();
        }

        [HttpPut]
        public async Task<RequestResponse> AlterarCategoria( [FromBody] CategoriaModel categoria)
        {
            return await service.EditCategoria(categoria);
        }

        [HttpDelete]
        public async Task<RequestResponse> ApagarCategoria([FromBody] CategoriaModel categoria)
        {
            return await service.DeleteCategoria(categoria);
        }
    }
}