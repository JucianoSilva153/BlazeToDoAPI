using BlazeToDo_API.ToDo;
using BlazeToDo_API.ToDo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazeToDo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

        private readonly TarefasService service;

        public TarefasController(TarefasService _service)
        {
            service = _service;
        }
        
        [HttpPost]
        public async Task<RequestResponse> CriarNovaTarefa([FromBody] TarefaModel tarefa)
        {
            return await service.CreateTask(tarefa);
        }

        [HttpGet]
        public async Task<RequestResponse> ListarTarefas()
        {
            return await service.ListTasks();
        }
    }
}