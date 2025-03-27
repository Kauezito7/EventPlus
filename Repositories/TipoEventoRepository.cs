using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_plus.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly Evento_Context _context;

        public TipoEventoRepository(Evento_Context context)
        {
            _context = context;
        }

        public void AtualizarTipoEvento(Guid id, TipoEvento tipoEventoAtualizado)
        {
            try
            {
                TipoEvento tipoBuscado = _context.TipoEvento.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public TipoEvento BuscarTipoEventoPorId(Guid idTipoEvento)
        {
            try
            {
                TipoEvento tipoEvento = _context.TipoEvento.Find(idTipoEvento)!;
                return tipoEvento;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void CadastrarTipoEvento(TipoEvento novoTipoEvento)
        {
            try
            {
                novoTipoEvento.IdTipoEvento = Guid.NewGuid();

                _context.TipoEvento.Add(novoTipoEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletarTipoEvento(Guid id)
        {
            try
            {
                TipoEvento tipoBuscado = _context.TipoEvento.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TipoEvento.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<TipoEvento> ListarTiposEvento()
        {
            try
            {
                return _context.TipoEvento
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
    
}


