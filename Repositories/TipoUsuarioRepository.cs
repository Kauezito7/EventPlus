using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.Interfaces;

namespace Event_plus.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly Evento_Context _context;
        public TipoUsuarioRepository(Evento_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                TipoUsuario tipoBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
                }

                _context.TipoUsuario.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                return _context.TipoUsuario.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoUsuario BuscarTipoUsuarioPorId(Guid Id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find()!;
                return tipoUsuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Cadastrar( TipoUsuario novoTipoUsuario)
        {
            try
            {
                novoTipoUsuario.IdTipoUsuario = Guid.NewGuid();
                
                _context.TipoUsuario.Add(novoTipoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TipoUsuario.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _context.TipoUsuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}

