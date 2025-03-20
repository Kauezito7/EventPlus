using Event_plus.Domains;
using Event_plus.Interfaces;
using Event_plus.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoDeEventoController : ControllerBase
    {

        private readonly ITipoEventoRepository _tipoDeEventoRepository;

        public TipoDeEventoController(ITipoEventoRepository tipoDeEventoRepository)
        {
            _tipoDeEventoRepository = tipoDeEventoRepository;
        }

        // Metodo de Cadastrar
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoDeEvento)
        {
            try
            {
                _tipoDeEventoRepository.CadastrarTipoEvento(novoTipoDeEvento);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Metodo Atualizar

        [HttpPut("{id}")]

        public IActionResult Put(Guid id, TipoEvento tipoDeEvento)
        {
            try
            {
                _tipoDeEventoRepository.AtualizarTipoEvento(id, tipoDeEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        //Metodo Deletar


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _tipoDeEventoRepository.DeletarTipoEvento(Id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoEvento> listaDeEventos = _tipoDeEventoRepository.ListarTiposEvento();
                return Ok(listaDeEventos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}

