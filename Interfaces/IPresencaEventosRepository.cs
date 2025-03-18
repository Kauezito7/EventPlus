using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface IPresencaEventosRepository
    {
        void AdicionarPresenca(PresencaEventos novaPresenca);
        PresencaEventos BuscarPresencaPorId(int idPresenca);
        List<PresencaEventos> ListarPresencas();
        void AtualizarPresenca(Guid id, PresencaEventos presencaAtualizada);
        void DeletarPresenca(Guid id);
    }
}
