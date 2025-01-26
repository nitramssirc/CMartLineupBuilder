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
    public abstract class AddProjectionsCommandBase:IRequest<AddProjectionsResponse>
    {
        public SlateID SlateID { get; }

        public abstract ProjectionSource ProjectionSource { get; }

        internal abstract IEnumerable<ProjectionDTO> GetProjections();

        protected AddProjectionsCommandBase(SlateID slateID)
        {
            SlateID = slateID;
        }
    }
}
