using Event_plus.Domains;
using Event_plus.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo usuario
        /// </summary>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.CadastrarUsuario(novoUsuario);

                return StatusCode(201, novoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }


        }

        /// <summary>
        /// Endpoint para buscar usuario por Id
        /// </summary>
        [HttpGet]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario novoUsuario = _usuarioRepository.BuscarUsuarioPorId(id);
                return Ok(novoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("BuscarPorEmailESenha/{email}, {senha}")]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                Usuario novoUsuario = _usuarioRepository.BuscarUsuarioPorEmailESenha(email, senha);
                return Ok(novoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
