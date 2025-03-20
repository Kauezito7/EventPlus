using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface ITipoEventoRepository
    {
        void CadastrarTipoEvento(TipoEvento novoTipoEvento);
        TipoEvento BuscarTipoEventoPorId(Guid idTipoEvento);
        List<TipoEvento> ListarTiposEvento();
        void AtualizarTipoEvento(Guid id, TipoEvento tipoEventoAtualizado);
        void DeletarTipoEvento(Guid id);
    }
}
