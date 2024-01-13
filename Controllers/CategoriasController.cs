using System.ComponentModel.DataAnnotations;
using BlazeToDo_API.ToDo;
using BlazeToDo_API.ToDo.DTO;
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
        public async Task<RequestResponse> CriarCategoria( [FromBody] CriaCategoriaDTO novaCategoria)
        {
            return await service.CreateCategoria(novaCategoria);
        }

        [HttpGet]
        public async Task<RequestResponse> ListarTodasCategorias()
        {
            return await service.ListAllCategorias();
        }

        [HttpPut]
        public async Task<RequestResponse> AlterarCategoria( [FromBody] ListaAlteraCategorias categoria)
        {
            return await service.EditCategoria(categoria);
        }

        [HttpDelete]
        [Route("/{id}")]
        public async Task<RequestResponse> ApagarCategoria(int id)
        {
            return await service.DeleteCategoria(id);
        }
    }
}