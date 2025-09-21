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
        #region Properties

        public SlateID SlateID { get; set; }
        public string Name { get; private set; }
        public Team Team { get; private set; }

        #endregion

        #region Constructor

        private PlayerID(
            SlateID slateID,
            string name, 
            Team team, 
            Guid id) : base(id)
        {
            SlateID = slateID;
            Name = name;
            Team = team;
        }

        #endregion

        #region Factory Method


        public static PlayerID CreateNew(
            SlateID slateID,
            string name,
            Team team)
        {
            return new PlayerID(slateID, name, team, Guid.NewGuid());
        }

        #endregion

        #region EntityID Overrides

        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            yield return SlateID;
            yield return Name;
            yield return Team;
        }

        #endregion

    }
}
