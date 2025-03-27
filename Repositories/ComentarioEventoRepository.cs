using System.Diagnostics;
using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.Interfaces;
using Microsoft.Extensions.Logging;

namespace Event_plus.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly Evento_Context _context;

        public ComentarioEventoRepository(Evento_Context context)
        {
            _context = context;
        }
        public ComentarioEvento BuscarPorIdUsuario(Guid UsuarioId, Guid IdEvento)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        IdComentario = c.IdComentario,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdUsuario == UsuarioId && c.IdEvento == IdEvento)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CadastrarComentario(ComentarioEvento novoComentario)
        {
            try
            {
                novoComentario.IdComentario = Guid.NewGuid();

                _context.ComentarioEvento.Add(novoComentario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletarComentario(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _context.ComentarioEvento.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentarioEvento.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentarioEvento> ListarComentarios(Guid idEvento)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        IdComentario = c.IdComentario,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.IdEvento == idEvento).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
    

