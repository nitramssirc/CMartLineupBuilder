using Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Monitors.Projections
{
    public class ProjectionsMonitor: IProjectionsMonitor
    {
        private readonly IProjectionRepo _projectionRepo;

        public ProjectionsMonitor(IProjectionRepo projectionRepo)
        {
            _projectionRepo = projectionRepo;
            _projectionRepo.ProjectionsUpdated += _projectionRepo_ProjectionsUpdated;
        }

        private void _projectionRepo_ProjectionsUpdated(object? sender, EventArgs e)
        {
            ProjectionsUpdated?.Invoke(this, e);
        }

        public event EventHandler ProjectionsUpdated;


    }
}
