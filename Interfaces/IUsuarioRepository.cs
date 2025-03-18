using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface IUsuarioRepository
    {
        void CadastrarUsuario(Usuario novoUsuario);
        Usuario BuscarUsuarioPorId(Guid id);
        Usuario BuscarUsuarioPorEmailESenha(string email, string senha);    
            
    }
}
