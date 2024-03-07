using Microsoft.EntityFrameworkCore;
using SistemadeTrabalho2.Data;
using SistemadeTrabalho2.Models;
using SistemadeTrabalho2.Repositorio.Interfaces;

namespace SistemadeTrabalho2.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly SistemaTarefaDbContext _dbcontext;

        public PedidoRepositorio(SistemaTarefaDbContext sistemaTarefasDbContext)
        {
            _dbcontext = sistemaTarefasDbContext;
        }

        public async Task<PedidoModel> BuscarPorId(int id)
        {
            return await _dbcontext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidoModel>> BuscarTodosPedidos()
        {
            return await _dbcontext.Pedidos.ToListAsync();
        }
        public async Task<PedidoModel> Adicionar(PedidoModel pedido)
        {
            await _dbcontext.Pedidos.AddAsync(pedido);
            await _dbcontext.SaveChangesAsync();

            return pedido;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidoModel pedido = await BuscarPorId(id);
            if (pedido == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Pedidos.Remove(pedido);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidoModel> Atualizar(PedidoModel pedido, int id)
        {
            PedidoModel pedidoporId = await BuscarPorId(id);
            if (pedidoporId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            pedidoporId.EnderEntr = pedido.EnderEntr;

            _dbcontext.Pedidos.Update(pedidoporId);
            await _dbcontext.SaveChangesAsync();
            return pedidoporId;
        }
    }
}
