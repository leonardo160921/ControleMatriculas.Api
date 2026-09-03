using System.Collections.Generic;

namespace ControleMatriculas.Api.Models
{
    public class AlunoPaginado
    {
        public IEnumerable<Aluno> Dados { get; set; }

        public int TotalRegistros { get; set; }
    }
}