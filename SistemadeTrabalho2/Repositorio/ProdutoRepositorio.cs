using Microsoft.EntityFrameworkCore;
using SistemadeTrabalho2.Data;
using SistemadeTrabalho2.Models;
using SistemadeTrabalho2.Repositorio.Interfaces;

namespace SistemadeTrabalho2.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SistemaTarefaDbContext _dbcontext;

        public ProdutoRepositorio(SistemaTarefaDbContext sistemaTarefasDbContext)
        {
            _dbcontext = sistemaTarefasDbContext;
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbcontext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbcontext.Produtos.ToListAsync();
        }
        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbcontext.Produtos.AddAsync(produto);
            await _dbcontext.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produto = await BuscarPorId(id);
            if (produto == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Produtos.Remove(produto);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            produtoPorId.Nome = produto.Nome;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.Preco = produto.Preco;

            _dbcontext.Produtos.Update(produtoPorId);
            await _dbcontext.SaveChangesAsync();
            return produtoPorId;
        }
    }
}

