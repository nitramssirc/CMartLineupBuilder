using Common.Enums;

using Domain.Common.Models;
using Domain.SlateAggregate.ValueTypes;

namespace Domain.SlateAggregate.Models
{
    public class Player : Entity<PlayerID>, IAggregateRoot
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public Sport Sport { get; private set; }

        #region Constructors

        private Player():base(new PlayerID())
        {
        }

        public Player(
            PlayerID id,
            string firstName,
            string lastName,
            Sport sport) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Sport = sport;
        }

        #endregion
    }
}
