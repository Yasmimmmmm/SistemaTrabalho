using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemadeTrabalho2.Models;

namespace SistemadeTrabalho2.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EnderEntr).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioId);
            builder.HasOne(x => x.Usuario);
        }
    }
}
