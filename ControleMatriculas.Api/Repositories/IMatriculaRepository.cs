using System.Collections.Generic;
using ControleMatriculas.Api.Models;

namespace ControleMatriculas.Api.Repositories
{
    public interface IMatriculaRepository
    {
        IEnumerable<Matricula> Listar();

        Matricula ObterPorId(int id);

        int Inserir(Matricula matricula);

        int Atualizar(Matricula matricula);

        int Excluir(int id);
    }
}