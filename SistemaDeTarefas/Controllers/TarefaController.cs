using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscasTodasTarefas();
            return Ok(tarefas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefas = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefas);
        }
        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefas = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefas);
        }
        [HttpPut]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id= id;
            TarefaModel tarefas = await _tarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefas);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _tarefaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
