using Application.Repositories;
using Application.Specifications;

using Domain.Common.Entities;

using Microsoft.EntityFrameworkCore;

using Repository.DbContexts;

public abstract class BaseRepository<TEntity> :
    ICommandRepository<TEntity>,
    IQueryRepository<TEntity>
    where TEntity : class, IAggregateRoot
{
    #region Fields

    private readonly CMartDbContext _context;

    #endregion

    #region Constructor

    protected BaseRepository(CMartDbContext context)
    {
        _context = context;
    }

    #endregion

    #region ICommandRepository Implementation
    
    public virtual async Task AddAsync(TEntity model)
    {
        await _context.Set<TEntity>().AddAsync(model);
    }

    public virtual async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    #endregion

    #region IQueryRepository Implementation

    public virtual async Task<TEntity?> GetEntity(ISpecification<TEntity> specification)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetEntities(ISpecification<TEntity> specification)
    {
        return await ApplySpecification(specification).ToListAsync();
    }

    #endregion

    #region Private Methods

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().Where(specification.Expression);

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        if (specification.UseSplitQuery)
        {
            query = query.AsSplitQuery();
        }

        return query;
    }

    #endregion

}