using Application.Repositories;
using Application.Specifications;

using Common.Enums;

using Domain.Aggregates;
using Domain.Common.Entities;
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
        BaseRepository<Slate>(context)
    {
                
    }
}
