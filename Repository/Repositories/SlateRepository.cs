using Application.Common.Repositories;

using Common.Enums;

using Domain.SlateAggregate.Models;
using Domain.SlateAggregate.ValueTypes;

using Microsoft.EntityFrameworkCore;

using Repository.DbContexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SlateRepository :
        ICommandRepository<Slate, SlateID>,
        IQueryRepository<Slate, SlateID>
    {
        #region Dependencies

        private readonly CMartDbContext _context;

        #endregion

        #region Constructor

        public SlateRepository(CMartDbContext context)
        {
            _context = context;
        }

        #endregion

        #region ICommandRespository Implementation

        async Task ICommandRepository<Slate, SlateID>.AddAsync(Slate model)
        {
            await _context.Slates.AddAsync(model);
        }

        async Task<Slate?> ICommandRepository<Slate, SlateID>.GetByIdAsync(SlateID id)
        {
            return await _context.Slates.FindAsync(id);
        }

        async Task ICommandRepository<Slate, SlateID>.SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion

        #region IQueryRepository Implementation

        async Task<IEnumerable<Slate>> IQueryRepository<Slate, SlateID>.FindAsync(Func<Slate, bool> predicate)
        {
            return await Task.Run(() => _context.Slates.AsNoTracking().Where(predicate).AsEnumerable());
        }

        async Task<IEnumerable<Slate>> IQueryRepository<Slate, SlateID>.GetAllAsync()
        {
            return await Task.Run(() => _context.Slates.AsNoTracking().AsEnumerable());
        }

        async Task<Slate?> IQueryRepository<Slate, SlateID>.GetByIdAsync(SlateID id)
        {
            return await _context.Slates.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        #endregion

    }
}
