﻿using SistemadeTrabalho2.Models;

namespace SistemadeTrabalho2.Repositorio.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<CategoriaModel>> BuscarTodasCategorias();

        Task<CategoriaModel> BuscarPorId(int Id);

        Task<CategoriaModel> Adicionar(CategoriaModel categoria);

        Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id);

        Task<bool> Apagar(int Id);
    }
}
