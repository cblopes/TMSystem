using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TMS.Business.Interfaces;
using TMS.Data.Context;

namespace TMS.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity> ObterPorId(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<List<TEntity>> ObterTodos()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task Adicionar(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChanges();
    }

    public virtual async Task Atualizar(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public abstract Task Remover(int id);

    public async Task<int> SaveChanges()
    {
        return await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}
