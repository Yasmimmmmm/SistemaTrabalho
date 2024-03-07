namespace SistemadeTrabalho2.Models
{
    public class PediProdModel
    {
        public int Id { get; set; } 
        public int ProdutoId { get; set; }
        public virtual ProdutoModel? Produto { get; set; }

        public int CategoriaId { get; set; }
        public virtual CategoriaModel? Categoria { get; set; }

        public int Quantidade { get; set; } 
    }
}
