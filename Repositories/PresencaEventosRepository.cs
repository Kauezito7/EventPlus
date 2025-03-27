using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_plus.Repositories
{
    public class PresencaEventosRepository : IPresencaEventosRepository
    {
        private readonly Evento_Context _context;

        public PresencaEventosRepository(Evento_Context context)
        {
            _context = context;
        }

        public void AtualizarPresenca(Guid id, PresencaEventos presencaAtualizada)
        {
            try
            {
                PresencaEventos presencaEventoBuscado = _context.PresencaEventos.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    if (presencaEventoBuscado.Situacao)
                    {
                        presencaEventoBuscado.Situacao = false;
                    }
                    else
                    {
                        presencaEventoBuscado.Situacao = true;
                    }

                }

                _context.PresencaEventos.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PresencaEventos BuscarPresencaPorId(Guid id)
        {
            try
            {
                return _context.PresencaEventos
                    .Select(p => new PresencaEventos
                    {
                        IdPresenca = p.IdPresenca,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            IdEvento = p.IdEvento!,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicao
                            {
                                IdInstituicao = p.Evento.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.IdPresenca == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletarPresenca(Guid id)
        {
            try
            {
                PresencaEventos presencaEventoBuscado = _context.PresencaEventos.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    _context.PresencaEventos.Remove(presencaEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(PresencaEventos novaPresenca)
        {
            try
            {
                novaPresenca.IdPresenca = Guid.NewGuid();

                _context.PresencaEventos.Add(novaPresenca);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEventos> ListarMinhasPresencas(Guid id)
        {
            {
                try
                {
                    List<PresencaEventos> listaPresenca = _context.PresencaEventos.Where(p => p.IdUsuario == id).ToList();
                    return listaPresenca;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<PresencaEventos> ListarPresencas()
        {
            try
            {
                return _context.PresencaEventos
                    .Select(p => new PresencaEventos
                    {
                        IdPresenca = p.IdPresenca,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            IdEvento = p.IdEvento,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicao
                            {
                                IdInstituicao = p.Evento.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
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
