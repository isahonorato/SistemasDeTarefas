using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Controllers
{
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return Ok();
        }
    }
}
