using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface IEventoRepository
    {
        void CadastrarEvento(Evento novoEvento);
        Evento BuscarPorId(Guid Id);
        List<Evento> ListarEventos();
        void AtualizarEvento(Guid id, Evento eventoAtualizado);
        void DeletarEvento(Guid id);

    }
}