using System.Web.Http;
using ControleMatriculas.Api.Models;
using ControleMatriculas.Api.Repositories;

namespace ControleMatriculas.Api.Controllers
{
    [RoutePrefix("api/turmas")]
    public class TurmasController : ApiController
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmasController(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Listar()
        {
            var turmas = _turmaRepository.Listar();

            return Ok(turmas);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Inserir(Turma turma)
        {
            var id = _turmaRepository.Inserir(turma);

            turma.Id = id;

            return Created(
                Request.RequestUri + "/" + id,
                turma);
        }
    }
}