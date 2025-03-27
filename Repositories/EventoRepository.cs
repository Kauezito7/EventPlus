using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.Interfaces;

namespace Event_plus.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Evento_Context _context;
        public EventoRepository(Evento_Context context)
        {
            _context = context;
        }
        public void AtualizarEvento(Guid id, Evento eventoAtualizado)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
                    eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
                    eventoBuscado.Descricao = eventoAtualizado.Descricao;
                    eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
                }

                _context.Evento.Update(eventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Evento> ListarProximosEventos(Guid id)
        {
            try
            {
                List<Evento> listarEventosProximos = _context.Evento.Where(e => e.DataEvento > DateTime.Now).OrderBy(e => e.DataEvento).ToList();
                return listarEventosProximos;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public Evento BuscarPorId(Guid Id)
        {
            try
            {
                return _context.Evento
                    .Select(e => new Evento
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEvento = new TipoEvento
                        {
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        Instituicao = new Instituicao
                        {
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).FirstOrDefault(e => e.IdEvento == Id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CadastrarEvento(Evento novoEvento)
        {
            try
            {
                // Verifica se a data do evento é maior que a data atual
                if (novoEvento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                novoEvento.IdEvento = Guid.NewGuid();

                _context.Evento.Add(novoEvento);

                _context.SaveChanges();
            }
            catch (Exception)   
            {
                throw;
            }
        }

        public void DeletarEvento(Guid id)
        {
            try
            {
                Evento EventoBuscado = _context?.Evento.Find(id)!;
                if (EventoBuscado != null)
                {
                    _context?.Evento.Remove(EventoBuscado);
                }
                _context?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Evento> ListarPorId(Guid id)
        {
            try
            {
                List<Evento> listaEvento = _context.Evento.Where(p => p.IdEvento == id).ToList();
                return listaEvento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ListarEventos()
        {
            try
            {
                return _context.Evento
                    .Select(e => new Evento
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TipoEvento = new TipoEvento
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicao
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
       }
    }

