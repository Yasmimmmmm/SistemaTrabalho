using Microsoft.AspNetCore.Mvc;
using SistemadeTrabalho2.Models;
using SistemadeTrabalho2.Repositorio;
using SistemadeTrabalho2.Repositorio.Interfaces;

namespace SistemadeTrabalho2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PediProdController : ControllerBase
    {
        private readonly IPediProdRepositorio _pediprodRepositorio;
        public PediProdController(IPediProdRepositorio pediProdRepositorio)
        {
            _pediprodRepositorio = pediProdRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PediProdModel>>> BuscarTodosPedidosProdutos()
        {
            List<PediProdModel> pediprod = await _pediprodRepositorio.BuscarTodosPedidosProdutos();
            return Ok(pediprod);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PediProdModel>> BuscarPorId(int id)
        {
            PediProdModel pediprod = await _pediprodRepositorio.BuscarPorId(id);
            return Ok(pediprod);
        }

        [HttpPost]

        public async Task<ActionResult<PediProdModel>> Adicionar([FromBody] PediProdModel pediProdModel)
        {
            PediProdModel pediprod = await _pediprodRepositorio.Adicionar(pediProdModel);
            return Ok(pediprod);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<PediProdModel>> Atualizar(int id, [FromBody] PediProdModel pediProdModel)
        {
            pediProdModel.Id = id;
            PediProdModel pediprod = await _pediprodRepositorio.Atualizar(pediProdModel, id);
            return Ok(pediprod);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<PediProdModel>> Apagar(int id)
        {
            bool apagado = await _pediprodRepositorio.Apagar(id);
            return Ok(apagado);
        }   
    }
}
