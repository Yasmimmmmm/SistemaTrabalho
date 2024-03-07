using Microsoft.AspNetCore.Mvc;
using SistemadeTrabalho2.Models;
using SistemadeTrabalho2.Repositorio.Interfaces;

namespace SistemadeTrabalho2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaModel>>> BuscarTodasCategorias()
        {
            List<CategoriaModel> categorias = await _categoriaRepositorio.BuscarTodasCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CategoriaModel>> BuscarPorId(int id)
        {
            CategoriaModel categoria = await _categoriaRepositorio.BuscarPorId(id);
            return Ok(categoria);
        }

        [HttpPost]

        public async Task<ActionResult<CategoriaModel>> Adicionar([FromBody] CategoriaModel categoriaModel)
        {
            CategoriaModel categoria = await _categoriaRepositorio.Adicionar(categoriaModel);
            return Ok(categoria);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<CategoriaModel>> Atualizar(int id, [FromBody] CategoriaModel categoriaModel)
        {
            categoriaModel.Id = id;
            CategoriaModel categoria = await _categoriaRepositorio.Atualizar(categoriaModel, id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<CategoriaModel>> Apagar(int id)
        {
            bool apagado = await _categoriaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
