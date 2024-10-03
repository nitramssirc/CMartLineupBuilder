using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PlayerExposure
    {
        public int ID { get; set; }

        public int PlayerID { get; set; }

        public int WeekID { get; set; }

        public Site Site { get; set; }

        public int MinExposurePct { get; set; }

        public int MaxExposurePct { get; set; }

        public bool Exclude { get; set; }
    }
}
