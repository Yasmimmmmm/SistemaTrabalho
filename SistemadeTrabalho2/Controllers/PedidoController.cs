﻿using Microsoft.AspNetCore.Mvc;
using SistemadeTrabalho2.Models;
using SistemadeTrabalho2.Repositorio.Interfaces;

namespace SistemadeTrabalho2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoModel>>> BuscarTodosPedidos()
        {
            List<PedidoModel> pedidos = await _pedidoRepositorio.BuscarTodosPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PedidoModel>> BuscarPorId(int id)
        {
            PedidoModel pedido = await _pedidoRepositorio.BuscarPorId(id);
            return Ok(pedido);
        }

        [HttpPost]

        public async Task<ActionResult<PedidoModel>> Adicionar([FromBody] PedidoModel pedidoModel)
        {
            PedidoModel pedido = await _pedidoRepositorio.Adicionar(pedidoModel);
            return Ok(pedido);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<PedidoModel>> Atualizar(int id, [FromBody] PedidoModel pedidoModel)
        {
            pedidoModel.Id = id;
            PedidoModel pedido = await _pedidoRepositorio.Atualizar(pedidoModel, id);
            return Ok(pedido);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<PedidoModel>> Apagar(int id)
        {
            bool apagado = await _pedidoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
