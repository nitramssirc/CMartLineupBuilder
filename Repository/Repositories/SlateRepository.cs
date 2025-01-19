using Application.Repositories;
using Application.Specifications;

using Common.Enums;

using Domain.Common.Entities;
using Domain.Entities;
using Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;

using Repository.DbContexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SlateRepository(CMartDbContext context) : 
        BaseRepository<Slate>(context),
        ICommandRepository<Slate>,
        IQueryRepository<Slate>
    {
        #region Dependencies

        private readonly CMartDbContext _context = context;

        #endregion

        #region ICommandRespository Implementation

        async Task ICommandRepository<Slate>.AddAsync(Slate model)
        {
            await _context.Slates.AddAsync(model);
        }

        async Task ICommandRepository<Slate>.SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        async Task<Slate?> ICommandRepository<Slate>.GetEntity(ISpecification<Slate> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        #endregion

        #region IQueryRepository Implementation

        public async Task<Slate?> GetEntity(ISpecification<Slate> specification)
        {
            return await ApplySpecification(specification).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Slate>> GetEntities(ISpecification<Slate> specification)
        {
            return await ApplySpecification(specification).AsNoTracking().ToListAsync();
        }

        #endregion

        
    }
}
