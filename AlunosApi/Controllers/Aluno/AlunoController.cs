using Microsoft.AspNetCore.Mvc;
using AlunosApi.Models.Aluno;
using AlunosApi.Services.Aluno;

namespace AlunosApi.Controllers.Aluno
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost("cadastrarAluno")]
        public AlunoModel Create([FromBody] AlunoModel aluno)
        {
            var retorno = _alunoService.CreateAluno(aluno);
            return retorno;
        }

        [HttpGet("buscarAluno/{id}")]
        public AlunoModel GetById([FromRoute] string id)
        {
           var retorno = _alunoService.BuscarAluno(id);
            return retorno;
        }

        [HttpGet("listarAlunos")]
        public List<AlunoModel> GetAll()
        {
            var retorno = _alunoService.BuscarTodos();
            return retorno;
        }


        [HttpDelete("deletarAluno/{id}")]
        public bool Delete([FromRoute] string id) {
            var retorno = _alunoService.DeletarAluno(id);
            return retorno;
        }


        [HttpPatch("atualizarAluno/{id}")]
        public AlunoModel Update([FromRoute] string id, [FromBody] AlunoModel aluno)
        {
            var retorno = _alunoService.UpdateAluno(id, aluno);
            return retorno;
        }
    }
}
