using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface IPresencaEventosRepository
    {
        void Inscrever(PresencaEventos novaPresenca);
        PresencaEventos BuscarPresencaPorId(Guid id);
        List<PresencaEventos> ListarPresencas();
        List<PresencaEventos> ListarMinhasPresencas(Guid id);
        void AtualizarPresenca(Guid id, PresencaEventos presencaAtualizada);
        void DeletarPresenca(Guid id);
    }
}
