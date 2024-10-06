using Microsoft.EntityFrameworkCore;
using TMS.Business.Entities;

namespace TMS.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Ocorrencia> Ocorrencias { get; set; }
}
