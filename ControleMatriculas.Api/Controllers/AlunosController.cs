using System.Web.Http;
using ControleMatriculas.Api.Repositories;

namespace ControleMatriculas.Api.Controllers
{
    [RoutePrefix("api/alunos")]
    public class AlunosController : ApiController
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunosController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Listar(
            int pagina = 1,
            int tamanhoPagina = 10,
            string nome = null)
        {
            var resultado = _alunoRepository.Listar(
                pagina,
                tamanhoPagina,
                nome);

            return Ok(resultado);
        }
    }
}