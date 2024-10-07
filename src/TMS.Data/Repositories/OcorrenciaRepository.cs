using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
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

    public async Task<Ocorrencia> ObterOcorrenciaPedido(int id)
    {
        return await Context.Ocorrencias
            .Include(x => x.Pedido)
            .FirstOrDefaultAsync(x => x.IdOcorrencia == id);
    }

    public override async Task Remover(int id)
    {
        DbSet.Remove(new() { IdOcorrencia = id });
        await SaveChanges();
    }
}
