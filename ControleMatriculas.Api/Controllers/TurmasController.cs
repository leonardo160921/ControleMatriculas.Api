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
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult ObterPorId(int id)
        {
            var turma = _turmaRepository.ObterPorId(id);

            if (turma == null)
                return NotFound();

            return Ok(turma);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Atualizar(int id, Turma turma)
        {
            turma.Id = id;

            var turmaExistente = _turmaRepository.ObterPorId(id);

            if (turmaExistente == null)
                return NotFound();

            _turmaRepository.Atualizar(turma);

            return Ok(turma);
        }
    }
}