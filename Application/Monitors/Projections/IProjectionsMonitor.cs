using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Monitors.Projections
{
    public interface IProjectionsMonitor
    {
        event EventHandler ProjectionsUpdated;
    }
}
