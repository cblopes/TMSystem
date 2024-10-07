using Microsoft.EntityFrameworkCore;
using TMS.Business.Entities;
using TMS.Business.Interfaces;
using TMS.Data.Context;

namespace TMS.Data.Repositories;

public class OcorrenciaRepository : Repository<Ocorrencia>, IOcorrenciaRepository
{
    public OcorrenciaRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Ocorrencia>> ObterOcorrenciasPorPedido(int pedidoId)
    {
        return await Context.Ocorrencias.Where(x => x.IdPedido == pedidoId).ToListAsync();
    }

    public override async Task Remover(int id)
    {
        DbSet.Remove(new() { IdOcorrencia = id });
        await SaveChanges();
    }
}
