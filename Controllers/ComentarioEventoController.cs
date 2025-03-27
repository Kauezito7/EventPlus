using Event_plus.Domains;
using Event_plus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController(IComentarioEventoRepository comentarioEventoRepository)
        {
            _comentarioEventoRepository = comentarioEventoRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo comentario do evento
        /// </summary>
        [HttpPost]
        public IActionResult Post(ComentarioEvento novoComentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.CadastrarComentario(novoComentarioEvento);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar novo comentario do evento
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.DeletarComentario(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para listar comentarios do evento
        /// </summary>
        [HttpGet]
        public IActionResult Get(Guid IdEvento)
        {
            try
            {
                List<ComentarioEvento> listaComentarioEvento = _comentarioEventoRepository.ListarComentarios(IdEvento);
                return Ok(listaComentarioEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar por id o comentario do usuario do evento
        /// </summary>
        [HttpGet("BuscarPorIdUsuario/{UsuarioID},{EventoID}")]
        public IActionResult GetById(Guid UsuarioID, Guid EventoID)
        {
            try
            {
                ComentarioEvento novoComentarioEvento = _comentarioEventoRepository.BuscarPorIdUsuario(UsuarioID, EventoID);
                return Ok(novoComentarioEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}