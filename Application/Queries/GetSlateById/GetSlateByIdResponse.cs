using Common.Enums;

using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetSlateById
{
    public class GetSlateByIdResponse
    {
        public Sport Sport { get; private set; }

        public GameType GameType { get; private set; }

        public DFSSite DFSSite { get; private set; }

        public string Name { get; private set; } = string.Empty;

        internal GetSlateByIdResponse(Slate slate)
        {
            Sport = slate.Sport;
            GameType = slate.GameType;
            DFSSite = slate.DFSSite;
            Name = slate.Name;
        }
    }
}
