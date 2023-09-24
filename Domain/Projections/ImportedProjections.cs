using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projections
{
    public class ImportedProjections
    {
        public DateTime ImportDateTime { get; set; }

        public RotoGrindersProjection[] RotoGrindersProjections { get; set; }
    }
}
