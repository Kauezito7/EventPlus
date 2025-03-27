using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario novoTipoUsuario);
        TipoUsuario BuscarTipoUsuarioPorId(Guid Id);
        List<TipoUsuario> Listar();
        void Atualizar(Guid id, TipoUsuario tipoUsuarioAtualizado);
        void Deletar(Guid id);
        TipoUsuario BuscarPorId(Guid id);

    }
}
