using ControleMatriculas.Api.Models;
using System.Collections.Generic;

namespace ControleMatriculas.Api.Repositories
{
    public interface ITurmaRepository
    {
        IEnumerable<Turma> Listar();

        int Inserir(Turma turma);
    }
}