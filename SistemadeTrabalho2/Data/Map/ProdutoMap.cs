using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemadeTrabalho2.Models;

namespace SistemadeTrabalho2.Data.Map
{
        public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
        {
            public void Configure(EntityTypeBuilder<ProdutoModel> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Preco).IsRequired().HasMaxLength(255);
            }
        }
}
