using SistemadeTrabalho2.Models;

namespace SistemadeTrabalho2.Repositorio.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<List<PedidoModel>> BuscarTodosPedidos();

        Task<PedidoModel> BuscarPorId(int Id);

        Task<PedidoModel> Adicionar(PedidoModel pedido);

        Task<PedidoModel> Atualizar(PedidoModel pedido, int id);

        Task<bool> Apagar(int Id);
    }
}
