using Microsoft.EntityFrameworkCore;
using TMS.Business.Entities;
using TMS.Business.Interfaces;
using TMS.Data.Context;

namespace TMS.Data.Repositories;

public class PedidoRepository : Repository<Pedido>, IPedidoRepository
{
    public PedidoRepository(AppDbContext context) : base(context) { }
    public async Task<Pedido> ObterPedidoOcorrencias(int id)
    {
        return await Context.Pedidos.AsNoTracking()
            .Include(x => x.Ocorrencias).FirstOrDefaultAsync(x => x.IdPedido == id);
    }

    public override async Task Remover(int id)
    {
        DbSet.Remove(new() { IdPedido = id });
        await SaveChanges();
    }
}
