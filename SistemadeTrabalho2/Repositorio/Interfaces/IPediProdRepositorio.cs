using SistemadeTrabalho2.Models;

namespace SistemadeTrabalho2.Repositorio.Interfaces
{
    public interface IPediProdRepositorio
    {
        Task<List<PediProdModel>> BuscarTodosPedidosProdutos();

        Task<PediProdModel> BuscarPorId(int Id);

        Task<PediProdModel> Adicionar(PediProdModel pediProd);

        Task<PediProdModel> Atualizar(PediProdModel pediProd, int id);

        Task<bool> Apagar(int Id);
    }
}
