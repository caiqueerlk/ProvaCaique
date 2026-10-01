using CascaApi.Models;
using CascaApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CascaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExemploController : ControllerBase
    {
        private readonly IExemploRepository _repo;

        public ExemploController(IExemploRepository repo) => _repo = repo;

        [HttpPost]
        public IActionResult Cadastrar(ExemploModel item)
        {
            if (_repo.BuscarPorCpf(item.Cpf) != null)
                return Conflict("Já existe um jogador cadastrado com esse CPF.");

            item.Posicao = item.Posicao.ToUpper();
            item.Aprovado = null;
            _repo.Adicionar(item);
            return Created("", item);
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.ListarTodos());

        [HttpPost("resultado")]
        public IActionResult RegistrarResultado(ExemploModel resultado)
        {
            var item = _repo.BuscarPorCpf(resultado.Cpf);
            if (item == null)
                return NotFound("Jogador não encontrado. O resultado não pode ser registrado.");

            if (item.Aprovado != null)
                return BadRequest("O resultado deste jogador já foi registrado.");

            item.Aprovado = resultado.Aprovado;
            return Ok(item);
        }

        [HttpGet("aprovados")]
        public IActionResult ListarAprovados() => Ok(_repo.ListarAprovados());
    }
}