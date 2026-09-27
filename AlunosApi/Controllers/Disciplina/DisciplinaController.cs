using AlunosApi.Models.Disciplina;
using AlunosApi.Services.Disciplina;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers.Disciplina
{

    [ApiController]
    [Route("[controller]")]
    public class DisciplinaController : ControllerBase
    {
        public DisciplinaService _disciplinaService;
        
        public DisciplinaController(DisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpPost("cadastrarDisciplina")]
        public DisciplinaModel Create([FromBody] DisciplinaModel disciplina)
        {
            var retorno = _disciplinaService.CadastrarDisciplina(disciplina);
            return retorno;
        }

        [HttpGet("buscarDisciplina/{id}")]
        public DisciplinaModel GetById([FromRoute] string id)
        {
            var retorno = _disciplinaService.BuscarDisciplina(id);
            return retorno;
        }

        [HttpGet("listarDisciplinas")]
        public List<DisciplinaModel> GetAll()
        {
            var retorno = _disciplinaService.ListarDisciplinas();
            return retorno;
        }

        [HttpDelete("deletarDisciplina/{id}")]
        public bool Delete([FromRoute] string id)
        {
            var retorno = _disciplinaService.DeletarDisciplina(id);
            return retorno;
        }

        [HttpPatch("atualizarDisciplina/{id}")]
        public DisciplinaModel Update([FromRoute] string id, [FromBody] DisciplinaModel disciplina)
        {
            var retorno = _disciplinaService.AtualizarDisciplina(id, disciplina);
            return retorno;
        }
    }
}
