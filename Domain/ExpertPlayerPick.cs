﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ExpertPlayerPick
    {
        public int ID { get; set; }

        public int PlayerID { get; set; }

        public int WeekID { get; set; }

        public Site Site { get; set; }

        public ProjectionSource Source { get; set; }

        public string PickName { get; set; } = string.Empty;
    }
}