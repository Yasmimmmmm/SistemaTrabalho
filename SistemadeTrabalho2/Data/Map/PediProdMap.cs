using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemadeTrabalho2.Models;

namespace SistemadeTrabalho2.Data.Map
{
    public class PediProdMap : IEntityTypeConfiguration<PediProdModel>
    {
        public void Configure(EntityTypeBuilder<PediProdModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProdutoId);
            builder.Property(x => x.CategoriaId);

            builder.HasOne(x => x.Produto);
            builder.HasOne(x => x.Categoria);
        }
    }
}
