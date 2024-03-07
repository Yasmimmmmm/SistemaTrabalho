using SistemadeTrabalho2.Models;

namespace SistemadeTrabalho2.Repositorio.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosProdutos();

        Task<ProdutoModel> BuscarPorId(int Id);

        Task<ProdutoModel> Adicionar(ProdutoModel produto);

        Task<ProdutoModel> Atualizar(ProdutoModel produto, int id);

        Task<bool> Apagar(int Id);
    }
}
