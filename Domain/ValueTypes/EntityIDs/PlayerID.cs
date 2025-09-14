using Common.Enums;

using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueTypes
{
    public class PlayerID : EntityID
    {
        public SlateID SlateID { get; set; }
        public string Name { get; private set; }
        public Team Team { get; private set; }

        public PlayerID(
            SlateID slateID,
            string name, 
            Team team, 
            Guid id) : base(id)
        {
            SlateID = slateID;
            Name = name;
            Team = team;
        }

        public PlayerID(SlateID slateID, string name, Team team) : 
            this(slateID, name, team, Guid.NewGuid())
        {
        }

        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            yield return SlateID;
            yield return Name;
            yield return Team;
        }
    }
}
