using Microsoft.EntityFrameworkCore;
using SistemadeTrabalho2.Data;
using SistemadeTrabalho2.Models;
using SistemadeTrabalho2.Repositorio.Interfaces;

namespace SistemadeTrabalho2.Repositorio
{
    public class PediProdRepositorio : IPediProdRepositorio
    {
        private readonly SistemaTarefaDbContext _dbcontext;

        public PediProdRepositorio(SistemaTarefaDbContext sistemaTarefasDbContext)
        {
            _dbcontext = sistemaTarefasDbContext;
        }

        public async Task<PediProdModel> BuscarPorId(int id)
        {
            return await _dbcontext.PediProds.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PediProdModel>> BuscarTodosPedidosProdutos()
        {
            return await _dbcontext.PediProds.ToListAsync();
        }
        public async Task<PediProdModel> Adicionar(PediProdModel pediprod)
        {
            await _dbcontext.PediProds.AddAsync(pediprod);
            await _dbcontext.SaveChangesAsync();

            return pediprod;
        }

        public async Task<bool> Apagar(int id)
        {
            PediProdModel pediprod = await BuscarPorId(id);
            if (pediprod == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.PediProds.Remove(pediprod);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<PediProdModel> Atualizar(PediProdModel pediprod, int id)
        {
            PediProdModel pediprodPorId = await BuscarPorId(id);
            if (pediprodPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            pediprodPorId.Quantidade = pediprod.Quantidade;


            _dbcontext.PediProds.Update(pediprodPorId);
            await _dbcontext.SaveChangesAsync();
            return pediprodPorId;
        }
    }
}
