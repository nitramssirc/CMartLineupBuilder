using Common.Enums;

using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProjections.Models
{
    public abstract class UploadedProjection
    {
        public abstract string Name { get; }

        public abstract Team Team { get; }

        public abstract IEnumerable<ProjectionData> ProjectionData { get; }

    }
}
