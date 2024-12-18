﻿using Application.Common.Repositories;

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

        public Task AddAsync(Slate model)
        {
            _context.Slates.Add(model);
            return Task.CompletedTask;
        }

        Task<Slate?> ICommandRepository<Slate, SlateID>.GetByIdAsync(SlateID id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Slate>> FindAsync(Func<Slate, bool> predicate)
        {
            var result = _context.Slates.AsNoTracking().Where(predicate).AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Slate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Slate?> IQueryRepository<Slate, SlateID>.GetByIdAsync(SlateID id)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
