using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.Business.Entities;

namespace TMS.Data.Mappings;

public class OcorrenciaMapping : IEntityTypeConfiguration<Ocorrencia>
{
    public void Configure(EntityTypeBuilder<Ocorrencia> builder)
    {
        builder.HasKey(x => x.IdOcorrencia);

        builder.Property(x => x.TipoOcorrencia)
            .HasConversion<string>()
            .HasColumnType("VARCHAR(20)")
            .IsRequired();

        builder.ToTable("Ocorrencias");
    }
}
