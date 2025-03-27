using Event_plus.Domains;
using Event_plus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo evento
        /// </summary>
        [HttpPost]
        public IActionResult Post(Evento eventoRepository)
        {
            try
            {
                _eventoRepository.CadastrarEvento(eventoRepository);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Enpoint para deleter um evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.DeletarEvento(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        /// <summary>
        /// Endpoint para listar Evento
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Evento> ListarEventos = _eventoRepository.ListarEventos();
                return Ok(ListarEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para Listar Evento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("ListarPorId/{id}")]
        public IActionResult ListarPorId(Guid id)
        {
            try
            {
                List<Evento> listaEventos = _eventoRepository.ListarPorId(id);
                return Ok(listaEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para listar proximos eventos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("ListarProximosEventos/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Evento> ListarEventos = _eventoRepository.ListarProximosEventos(id);
                return Ok(ListarEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        /// <summary>
        /// Endpoint para atualizar evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="novoEvento"></param>
        /// <returns></returns>

        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Evento novoEvento)
        {
            try
            {
                _eventoRepository.AtualizarEvento(id, novoEvento);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}