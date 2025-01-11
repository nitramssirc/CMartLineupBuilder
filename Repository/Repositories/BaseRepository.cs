using Application.Specifications;

using Domain.Common.Entities;
using Domain.Common.ValueTypes;

using Microsoft.EntityFrameworkCore;

using Repository.DbContexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public abstract class BaseRepository<TEntity, TId> where TEntity : Entity<TId> where TId : EntityID
    {
        #region Fields

        private CMartDbContext _context;

        #endregion

        #region Constructor

        protected BaseRepository(CMartDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Protected Methods

        protected IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(specification.Expression);

            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }
                        
            return query;
        }

        #endregion
    }
}
