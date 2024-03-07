using Microsoft.EntityFrameworkCore;
using SistemadeTrabalho2.Data;
using SistemadeTrabalho2.Models;
using SistemadeTrabalho2.Repositorio.Interfaces;

namespace SistemadeTrabalho2.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefaDbContext _dbcontext;

        public UsuarioRepositorio(SistemaTarefaDbContext sistemaTarefasDbContext)
        {
            _dbcontext = sistemaTarefasDbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbcontext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbcontext.Usuarios.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuario = await BuscarPorId(id);
            if (usuario == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Usuarios.Remove(usuario);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbcontext.Usuarios.Update(usuarioPorId);
            await _dbcontext.SaveChangesAsync();
            return usuarioPorId;
        }


    }
}

