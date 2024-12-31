using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum PlayerPosition
    {
        [WhichSport([Sport.NFL])]
        QB,
        [WhichSport([Sport.NFL])]
        RB,
        [WhichSport([Sport.NFL])]
        WR,
        [WhichSport([Sport.NFL])]
        TE,
        [WhichSport([Sport.NFL])]
        K,
        [WhichSport([Sport.NFL])]
        DST,
        [WhichSport([Sport.NBA])]
        PG,
        [WhichSport([Sport.NBA])]
        SG,
        [WhichSport([Sport.NBA])]
        SF,
        [WhichSport([Sport.NBA])]
        PF,
        [WhichSport([Sport.NBA])]
        C
    }
}
