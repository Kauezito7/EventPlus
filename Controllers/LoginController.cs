using Event_plus.Domains;
using Event_plus.DTOS;
using Event_plus.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Metodo responsavel por autenticar o usuario
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarUsuarioPorEmailESenha(loginDTO.Email, loginDTO.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario nao encontrado, email ou senha invalidos!");

                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),
                    new Claim("Tipo do usuario", usuarioBuscado.IdTipoUsuario.ToString()!),

                    new Claim("Nome da Claim", "Valor da Claim")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventos-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                        issuer: "api_filmes_senai",

                        audience: "api_filmes_senai",

                        claims: claims,

                        expires: DateTime.Now.AddMinutes(5),

                        signingCredentials: creds
                    );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                    );

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

