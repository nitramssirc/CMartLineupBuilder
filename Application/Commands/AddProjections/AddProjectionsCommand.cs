using Application.Commands.AddProjections.Models;

using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProjections
{
    public class AddProjectionsCommand:IRequest<AddProjectionsResponse>
    {
        public SlateID SlateID { get; }

        public ProjectionSource ProjectionSource { get; }

        public IEnumerable<UploadedProjection> UploadedProjections { get; }

        public AddProjectionsCommand(SlateID slateID, 
            ProjectionSource projectionSource,
            IEnumerable<UploadedProjection> projections)
        {
            SlateID = slateID;
            ProjectionSource = projectionSource;
            UploadedProjections = projections;
        }
    }
}
