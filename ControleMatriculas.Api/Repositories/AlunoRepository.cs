using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using ControleMatriculas.Api.Models;
using System.Linq;
using System.Data;

namespace ControleMatriculas.Api.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _connectionString;

        public AlunoRepository()
        {
            _connectionString =
                ConfigurationManager
                    .ConnectionStrings["TesteEscola"]
                    .ConnectionString;
        }

        public AlunoPaginado Listar(int pagina, int tamanhoPagina, string nome)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new
                {
                    Pagina = pagina,
                    TamanhoPagina = tamanhoPagina,
                    Nome = nome
                };

                var resultado = connection.Query<AlunoListaResultado>(
                "dbo.usp_Aluno_Listar", parametros,
                commandType: System.Data.CommandType.StoredProcedure);

                var alunos = resultado
                    .Select(x => new Aluno
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        DataNascimento = x.DataNascimento,
                        Ativo = x.Ativo,
                        DataCadastro = x.DataCadastro
                    })
                    .ToList();

                var totalRegistros = resultado.Any()
                    ? resultado.First().TotalRegistros
                    : 0;

                return new AlunoPaginado
                {
                    Dados = alunos,
                    TotalRegistros = totalRegistros
                };
            }
        }
        public Aluno ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Aluno>(
                    "dbo.usp_Aluno_ObterPorId",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public int Inserir(Aluno aluno)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingle<int>(
                    "dbo.usp_Aluno_Inserir",
                    new
                    {
                        Nome = aluno.Nome,
                        Email = aluno.Email,
                        DataNascimento = aluno.DataNascimento,
                        Ativo = aluno.Ativo
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Atualizar(Aluno aluno)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(
                    "dbo.usp_Aluno_Atualizar",
                    new
                    {
                        Id = aluno.Id,
                        Nome = aluno.Nome,
                        Email = aluno.Email,
                        DataNascimento = aluno.DataNascimento,
                        Ativo = aluno.Ativo
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Excluir(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(
                    "dbo.usp_Aluno_Excluir",
                    new
                    {
                        Id = id
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}