using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddSalaries
{
    public class SalaryData
    {
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public string Team { get; set; }
        public string SiteID { get; set; }

        public SalaryData(string playerName, string position, int salary, string team, string siteID)
        {
            PlayerName = playerName;
            Position = position;
            Salary = salary;
            Team = team;
            SiteID = siteID;
        }

        private SalaryData()
        {
            PlayerName = string.Empty;
            Position = string.Empty;
            Salary = 0;
            Team = string.Empty;
            SiteID = string.Empty;
        }
    }
}
