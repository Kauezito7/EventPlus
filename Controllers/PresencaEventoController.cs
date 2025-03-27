using Event_plus.Domains;
using Event_plus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaController : ControllerBase
    {
        private readonly IPresencaEventosRepository _presencaRepository;

        public PresencaController(IPresencaEventosRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }
        /// <summary>
        /// Endpoint para deletar a presença
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaRepository.DeletarPresenca(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar por Id a presença
        /// </summary>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                PresencaEventos novaPresenca = _presencaRepository.BuscarPresencaPorId(id);
                return Ok(novaPresenca);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar as presenças
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencaEventos presenca)
        {
            try
            {
                _presencaRepository.AtualizarPresenca(id, presenca);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das presenças
        /// </summary>
        [HttpGet("ListarPresencas")]
        public IActionResult Get()
        {
            try
            {
                List<PresencaEventos> listaPresencas = _presencaRepository.ListarPresencas();
                return Ok(listaPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das minhas presenças
        /// </summary>
        [HttpGet("PresencaEventos/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<PresencaEventos> listaMinhasPresencas = _presencaRepository.ListarMinhasPresencas(id);
                return Ok(listaMinhasPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para inscrever em um evento
        /// </summary>
        /// <param name="novaPresenca"></param>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Post(PresencaEventos novaPresenca)
        {

            try
            {
                _presencaRepository.Inscrever (novaPresenca);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
