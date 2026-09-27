using AlunosApi.Models.Professor;
using AlunosApi.Services.Professor;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers.Professor
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorService _professorService;

        public ProfessorController(ProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpPost("cadastrarProfessor")]
        public ProfessorModel Create([FromBody] ProfessorModel professor)
        {
            var retorno = _professorService.CadastrarProfessor(professor);
            return retorno;
        }

        [HttpGet("buscarProfessor/{id}")]
        public ProfessorModel GetById([FromRoute] string id)
        {
            var retorno = _professorService.BuscarProfessor(id);
            return retorno;
        }

        [HttpGet("listarProfessors")]
        public List<ProfessorModel> GetAll()
        {
            var retorno = _professorService.ListarProfessores();
            return retorno;
        }

        [HttpDelete("deletarProfessor/{id}")]
        public bool Delete([FromRoute] string id)
        {
            var retorno = _professorService.DeletarProfessor(id);
            return retorno;
        }

        [HttpPatch("atualizarProfessor/{id}")]
        public ProfessorModel Update([FromRoute] string id, [FromBody] ProfessorModel professor)
        {
            var retorno = _professorService.AtualizarProfessor(id, professor);
            return retorno;
        }
    }
}
