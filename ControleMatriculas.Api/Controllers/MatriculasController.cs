using System.Web.Http;
using ControleMatriculas.Api.Models;
using ControleMatriculas.Api.Repositories;

namespace ControleMatriculas.Api.Controllers
{
    [RoutePrefix("api/matriculas")]
    public class MatriculasController : ApiController
    {
        private readonly IMatriculaRepository _repository;

        public MatriculasController(IMatriculaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/matriculas
        [HttpGet]
        [Route("")]
        public IHttpActionResult Listar()
        {
            var matriculas = _repository.Listar();

            return Ok(matriculas);
        }

        // GET: api/matriculas/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult ObterPorId(int id)
        {
            var matricula = _repository.ObterPorId(id);

            if (matricula == null)
            {
                return NotFound();
            }

            return Ok(matricula);
        }

        // POST: api/matriculas
        [HttpPost]
        [Route("")]
        public IHttpActionResult Inserir(Matricula matricula)
        {
            var id = _repository.Inserir(matricula);

            return Created(
                Request.RequestUri + "/" + id,
                new
                {
                    Id = id
                });
        }

        // PUT: api/matriculas/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Atualizar(int id, Matricula matricula)
        {
            matricula.Id = id;

            var linhasAfetadas = _repository.Atualizar(matricula);

            if (linhasAfetadas == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/matriculas/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Excluir(int id)
        {
            var linhasAfetadas = _repository.Excluir(id);

            if (linhasAfetadas == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}