using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Line
    {
        public int ID { get; set; }

        public int WeekID { get; set; }

        public int GameID { get; set; }

        public decimal HomeTotal { get; set; }

        public decimal AwayTotal { get; set; }

        public decimal HomeSpread => HomeTotal - AwayTotal;

        public decimal AwaySpread => AwayTotal - HomeTotal;

        public decimal GameTotal => HomeTotal + AwayTotal;
    }
}
