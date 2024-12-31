using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum Team
    {
        UNKNOWN,
        [WhichSport([Sport.NFL])]
        ARI,
        [WhichSport([Sport.NFL, Sport.NBA])]
        ATL,
        [WhichSport([Sport.NFL])]
        BAL,
        [WhichSport([Sport.NFL])]
        BUF,
        [WhichSport([Sport.NFL])]
        CAR,
        [WhichSport([Sport.NFL, Sport.NBA])]
        CHI,
        [WhichSport([Sport.NFL])]
        CIN,
        [WhichSport([Sport.NFL, Sport.NBA])]
        CLE,
        [WhichSport([Sport.NFL, Sport.NBA])]
        DAL,
        [WhichSport([Sport.NFL, Sport.NBA])]
        DEN,
        [WhichSport([Sport.NFL, Sport.NBA])]
        DET,
        [WhichSport([Sport.NFL])]
        GB,
        [WhichSport([Sport.NFL, Sport.NBA])]
        HOU,
        [WhichSport([Sport.NFL, Sport.NBA])]
        IND,
        [WhichSport([Sport.NFL])]
        JAX,
        [WhichSport([Sport.NFL])]
        KC,
        [WhichSport([Sport.NFL, Sport.NBA])]
        LAC,
        [WhichSport([Sport.NFL])]
        LAR,
        [WhichSport([Sport.NFL])]
        LV,
        [WhichSport([Sport.NFL, Sport.NBA])]
        MIA,
        [WhichSport([Sport.NFL, Sport.NBA])]
        MIN,
        [WhichSport([Sport.NFL])]
        NE,
        [WhichSport([Sport.NFL, Sport.NBA])]
        NO,
        [WhichSport([Sport.NFL])]
        NYG,
        [WhichSport([Sport.NFL])]
        NYJ,
        [WhichSport([Sport.NFL, Sport.NBA])]
        PHI,
        [WhichSport([Sport.NFL])]
        PIT,
        [WhichSport([Sport.NFL])]
        SEA,
        [WhichSport([Sport.NFL])]
        SF,
        [WhichSport([Sport.NFL])]
        TB,
        [WhichSport([Sport.NFL])]
        TEN,
        [WhichSport([Sport.NFL, Sport.NBA])]
        WAS,
        [WhichSport([Sport.NBA])]
        BOS,
        [WhichSport([Sport.NBA])]
        BKN,
        [WhichSport([Sport.NBA])]
        CHA,
        [WhichSport([Sport.NBA])]
        GS,
        [WhichSport([Sport.NBA])]
        LAL,
        [WhichSport([Sport.NBA])]
        MEM,
        [WhichSport([Sport.NBA])]
        MIL,
        [WhichSport([Sport.NBA])]
        NY,
        [WhichSport([Sport.NBA])]
        OKC,
        [WhichSport([Sport.NBA])]
        ORL,
        [WhichSport([Sport.NBA])]
        PHX,
        [WhichSport([Sport.NBA])]
        POR,
        [WhichSport([Sport.NBA])]
        SAC,
        [WhichSport([Sport.NBA])]
        SA,
        [WhichSport([Sport.NBA])]
        TOR,
        [WhichSport([Sport.NBA])]
        UTA,
    }
}
