using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ControleMatriculas.Api.Models;
using System.Collections.Generic;

namespace ControleMatriculas.Api.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly string _connectionString;

        public TurmaRepository()
        {
            _connectionString =
                ConfigurationManager
                    .ConnectionStrings["TesteEscola"]
                    .ConnectionString;
        }

        public IEnumerable<Turma> Listar()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Turma>(
                    "dbo.usp_Turma_Listar",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }
    }
}