using BlazeToDo_API.ToDo;
using BlazeToDo_API.ToDo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazeToDo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListasController : ControllerBase
    {
        private readonly ListasService service;
        public ListasController(ListasService _service)
        {
            service = _service;
        }
        
        [HttpPost]
        public async Task<RequestResponse> NovaListaTarefas([FromBody] ListaModel lista)
        {
            return await service.CreateTaskList(lista);
        }

        [HttpGet]
        public async Task<RequestResponse> ListarListasTarefas()
        {
            return await service.ListTaskList();
        }
    }
}
