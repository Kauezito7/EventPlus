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
            TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(id)!;

            if (tipoEventoBuscado != null)
            {
                tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;
            }

        }

        public TipoEvento BuscarTipoEventoPorId(Guid idTipoEvento)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(idTipoEvento)!;

                return tipoEventoBuscado;
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
                TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(id)!;
                if (tipoEventoBuscado != null)
                {
                    _context.TipoEvento.Remove(tipoEventoBuscado);
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
                List<TipoEvento> listaDeTipos = _context.TipoEvento.Include(g => g.TituloTipoEvento).ToList();

                return listaDeTipos;
            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
    
}


