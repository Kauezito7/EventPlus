using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void CadastrarComentario(ComentarioEvento novoComentario);
        ComentarioEvento BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId);
        List<ComentarioEvento> ListarComentarios(Guid idEvento);
        void DeletarComentario(Guid id);
            
    }
}
