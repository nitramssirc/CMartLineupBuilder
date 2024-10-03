using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Lineup
    {
        public int ID { get; set; }

        public int WeekID { get; set; }

        public Site Site { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
       
    }
}
