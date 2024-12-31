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
        [TeamSport([Sport.NFL])]
        ARI,
        [TeamSport([Sport.NFL, Sport.NBA])]
        ATL,
        [TeamSport([Sport.NFL])]
        BAL,
        [TeamSport([Sport.NFL])]
        BUF,
        [TeamSport([Sport.NFL])]
        CAR,
        [TeamSport([Sport.NFL, Sport.NBA])]
        CHI,
        [TeamSport([Sport.NFL])]
        CIN,
        [TeamSport([Sport.NFL, Sport.NBA])]
        CLE,
        [TeamSport([Sport.NFL, Sport.NBA])]
        DAL,
        [TeamSport([Sport.NFL, Sport.NBA])]
        DEN,
        [TeamSport([Sport.NFL, Sport.NBA])]
        DET,
        [TeamSport([Sport.NFL])]
        GB,
        [TeamSport([Sport.NFL, Sport.NBA])]
        HOU,
        [TeamSport([Sport.NFL, Sport.NBA])]
        IND,
        [TeamSport([Sport.NFL])]
        JAX,
        [TeamSport([Sport.NFL])]
        KC,
        [TeamSport([Sport.NFL, Sport.NBA])]
        LAC,
        [TeamSport([Sport.NFL])]
        LAR,
        [TeamSport([Sport.NFL])]
        LV,
        [TeamSport([Sport.NFL, Sport.NBA])]
        MIA,
        [TeamSport([Sport.NFL, Sport.NBA])]
        MIN,
        [TeamSport([Sport.NFL])]
        NE,
        [TeamSport([Sport.NFL, Sport.NBA])]
        NO,
        [TeamSport([Sport.NFL])]
        NYG,
        [TeamSport([Sport.NFL])]
        NYJ,
        [TeamSport([Sport.NFL, Sport.NBA])]
        PHI,
        [TeamSport([Sport.NFL])]
        PIT,
        [TeamSport([Sport.NFL])]
        SEA,
        [TeamSport([Sport.NFL])]
        SF,
        [TeamSport([Sport.NFL])]
        TB,
        [TeamSport([Sport.NFL])]
        TEN,
        [TeamSport([Sport.NFL, Sport.NBA])]
        WAS,
        [TeamSport([Sport.NBA])]
        BOS,
        [TeamSport([Sport.NBA])]
        BKN,
        [TeamSport([Sport.NBA])]
        CHA,
        [TeamSport([Sport.NBA])]
        GS,
        [TeamSport([Sport.NBA])]
        LAL,
        [TeamSport([Sport.NBA])]
        MEM,
        [TeamSport([Sport.NBA])]
        MIL,
        [TeamSport([Sport.NBA])]
        NY,
        [TeamSport([Sport.NBA])]
        OKC,
        [TeamSport([Sport.NBA])]
        ORL,
        [TeamSport([Sport.NBA])]
        PHX,
        [TeamSport([Sport.NBA])]
        POR,
        [TeamSport([Sport.NBA])]
        SAC,
        [TeamSport([Sport.NBA])]
        SA,
        [TeamSport([Sport.NBA])]
        TOR,
        [TeamSport([Sport.NBA])]
        UTA,
    }

    //Attribute to assign a team to a sport
    public class TeamSportAttribute : Attribute
    {
        public TeamSportAttribute(Sport[] sports)
        {
            Sports = sports;
        }

        public Sport[] Sports { get; }
    }
}
