using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ControleMatriculas.Api.Models;

namespace ControleMatriculas.Api.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly string _connectionString;

        public MatriculaRepository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["TesteEscola"]
                .ConnectionString;
        }

        public IEnumerable<Matricula> Listar()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Matricula>(
                    "usp_Matricula_Listar",
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Matricula ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Matricula>(
                    "usp_Matricula_ObterPorId",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int Inserir(Matricula matricula)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(
                    "usp_Matricula_Inserir",
                    new
                    {
                        matricula.AlunoId,
                        matricula.TurmaId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int Atualizar(Matricula matricula)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(
                    "usp_Matricula_Atualizar",
                    new
                    {
                        matricula.Id,
                        matricula.AlunoId,
                        matricula.TurmaId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int Excluir(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(
                    "usp_Matricula_Excluir",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}