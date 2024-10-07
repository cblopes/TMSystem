using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.Business.Entities;

namespace TMS.Data.Mappings;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(x => x.IdPedido);

        builder.HasMany(x => x.Ocorrencias)
            .WithOne(x => x.Pedido)
            .HasForeignKey(x => x.IdPedido);

        builder.ToTable("Pedidos");
    }
}
