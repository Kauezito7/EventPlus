using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.Interfaces;
using Event_plus.Utils;

namespace Event_plus.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Evento_Context _context;
        public UsuarioRepository(Evento_Context context)
        {
            _context = context;
        }

        public Usuario BuscarUsuarioPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.IdUsuario,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }

                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }






        public Usuario BuscarUsuarioPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.TipoUsuario!.IdTipoUsuario,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }

                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;

                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CadastrarUsuario(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.IdUsuario = Guid.NewGuid();


                _context.Usuario.Add(novoUsuario);


                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
