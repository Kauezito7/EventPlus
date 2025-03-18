using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface IInstituicaoRepository
    {
        void CadastrarInstituicao(Instituicao novaInstituicao);
        Instituicao BuscarInstituicaoPorId(int idInstituicao);
        List<Instituicao> ListarInstituicoes();
        void AtualizarInstituicao(Guid id, Instituicao instituicaoAtualizada);
        void DeletarInstituicao(Guid id);

    }
}
