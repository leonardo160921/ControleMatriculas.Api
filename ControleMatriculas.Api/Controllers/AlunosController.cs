using System.Web.Http;
using ControleMatriculas.Api.Models;
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
        public IHttpActionResult Listar(int pagina = 1, int tamanhoPagina = 10, string nome = null)
        {
            var resultado = _alunoRepository.Listar(
                pagina,
                tamanhoPagina,
                nome);

            return Ok(resultado);
        }
        [HttpGet]
        [Route("{id:int}", Name = "ObterAlunoPorId")]
        public IHttpActionResult ObterPorId(int id)
        {
            var aluno = _alunoRepository.ObterPorId(id);

            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult Inserir(Aluno aluno)
        {
            var id = _alunoRepository.Inserir(aluno);

            aluno.Id = id;

            return CreatedAtRoute(
                "ObterAlunoPorId",
                new { id = aluno.Id },
                aluno);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Atualizar(int id, Aluno aluno)
        {
            var alunoExistente = _alunoRepository.ObterPorId(id);

            if (alunoExistente == null)
                return NotFound();

            aluno.Id = id;

            _alunoRepository.Atualizar(aluno);

            var alunoAtualizado = _alunoRepository.ObterPorId(id);

            return Ok(alunoAtualizado);
        }

    }
}