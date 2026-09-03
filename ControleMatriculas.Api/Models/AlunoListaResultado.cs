namespace ControleMatriculas.Api.Models
{
    public class AlunoListaResultado
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public System.DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }

        public System.DateTime DataCadastro { get; set; }

        public int TotalRegistros { get; set; }
    }
}