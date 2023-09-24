using Domain;

using Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetWeeks
{
    public class GetWeeksQuery : IGetWeeksQuery
    {
        private readonly IWeekRepo _weekRepo;

        public GetWeeksQuery(IWeekRepo weekRepo)
        {
            _weekRepo = weekRepo;
        }

        public async Task<Week[]> Execute()
        {
            return await _weekRepo.LoadWeeks();
        }
    }
}
