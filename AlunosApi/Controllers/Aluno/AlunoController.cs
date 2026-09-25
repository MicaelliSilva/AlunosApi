using Microsoft.AspNetCore.Mvc;
using AlunosApi.Models.Aluno;
using AlunosApi.Services;

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
        public AlunoModel Post([FromBody] AlunoModel aluno)
        {
            var retorno = _alunoService.CreateAluno(aluno);
            return retorno;
        }

        [HttpGet("buscarAluno/{id}")]
        public AlunoModel Get([FromRoute] string id)
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


        [HttpDelete("deletarAlunos/{id}")]
        public bool Delete([FromRoute] string id) {
            var retorno = _alunoService.DeletarAluno(id);
            return retorno;
        } 

        // fazer um endpoint de update (pelo id)
    }
}
