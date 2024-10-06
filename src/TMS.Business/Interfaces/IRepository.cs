﻿using System.Linq.Expressions;

namespace TMS.Business.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    Task Adicionar(TEntity entity);
    Task<TEntity> ObterPorId(int id);
    Task<List<TEntity>> ObterTodos();
    Task Atualizar(TEntity entity);
    Task Remover(int id);
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}
