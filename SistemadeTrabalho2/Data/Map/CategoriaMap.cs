using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemadeTrabalho2.Models;

namespace SistemadeTrabalho2.Data.Map
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaModel>
    {
        public void Configure(EntityTypeBuilder<CategoriaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(255);
        }
    }
}
