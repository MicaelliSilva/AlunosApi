using AlunosApi.Models.Curso;
using AlunosApi.Services.Curso;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers.Curso
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        public CursoService _cursoService;

        public CursoController(CursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpPost("cadastrarCurso")]
        public CursoModel Create([FromBody] CursoModel curso)
        {
            var retorno = _cursoService.CadastrarCurso(curso);
            return retorno;
        }

        [HttpGet("buscarCurso/{id}")]
        public CursoModel GetById([FromRoute] string id)
        {
            var retorno = _cursoService.BuscarCurso(id);
            return retorno;
        }

        [HttpGet("listarCursos")]
        public List<CursoModel> GetAll()
        {
            var retorno = _cursoService.ListarCursos();
            return retorno;
        }

        [HttpDelete("deletarCurso/{id}")]
        public bool Delete([FromRoute] string id)
        {
            var retorno = _cursoService.DeletarCurso(id);
            return retorno;
        }

        [HttpPatch("atualizarCurso/{id}")]
        public CursoModel Update([FromRoute] string id, [FromBody] CursoModel curso)
        {
            var retorno = _cursoService.AtualizarCurso(id, curso);
            return retorno;
        }
    }
}
