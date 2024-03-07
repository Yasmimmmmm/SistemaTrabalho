using Microsoft.EntityFrameworkCore;
using SistemadeTrabalho2.Data;
using SistemadeTrabalho2.Models;
using SistemadeTrabalho2.Repositorio.Interfaces;

namespace SistemadeTrabalho2.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly SistemaTarefaDbContext _dbcontext;

        public CategoriaRepositorio(SistemaTarefaDbContext sistemaTarefasDbContext)
        {
            _dbcontext = sistemaTarefasDbContext;
        }

        public async Task<CategoriaModel> BuscarPorId(int id)
        {
            return await _dbcontext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoriaModel>> BuscarTodasCategorias()
        {
            return await _dbcontext.Categorias.ToListAsync();
        }
        public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
        {
            await _dbcontext.Categorias.AddAsync(categoria);
            await _dbcontext.SaveChangesAsync();

            return categoria;
        }

        public async Task<bool> Apagar(int id)
        {
            CategoriaModel categoria = await BuscarPorId(id);
            if (categoria == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Categorias.Remove(categoria);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id)
        {
            CategoriaModel categoriaPorId = await BuscarPorId(id);
            if (categoriaPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            categoriaPorId.Nome = categoria.Nome;
            categoriaPorId.Status = categoria.Status;

            _dbcontext.Categorias.Update(categoriaPorId);
            await _dbcontext.SaveChangesAsync();
            return categoriaPorId;
        }
    }
}
