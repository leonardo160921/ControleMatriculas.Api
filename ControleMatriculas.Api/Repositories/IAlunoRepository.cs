using ControleMatriculas.Api.Models;

namespace ControleMatriculas.Api.Repositories
{
    public interface IAlunoRepository
    {
        AlunoPaginado Listar(
            int pagina,
            int tamanhoPagina,
            string nome);

        Aluno ObterPorId(int id);
        int Inserir(Aluno aluno);

        void Atualizar(Aluno aluno);
    }
}