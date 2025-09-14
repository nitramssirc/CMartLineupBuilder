using Common.Enums;

using Domain.Common.Entities;
using Domain.Events;
using Domain.Events.SlateEvents;
using Domain.ValueTypes;

namespace Domain.Aggregates
{
    public class Slate : Entity<SlateID>, IAggregateRoot
    {
        #region Properties

        public DateTime Date { get; private set; }

        public Sport Sport { get; private set; }

        public GameType GameType { get; private set; }

        public DFSSite DFSSite { get; private set; }

        public string Name { get; private set; } = string.Empty;

        #endregion

        #region Constructors

        private Slate() : base(new SlateID()) { }

        internal Slate(
            SlateID id,
            DateTime date,
            Sport sport,
            GameType gameType,
            DFSSite dfsSite,
            string name) : base(id)
        {
            Date = date;
            Sport = sport;
            GameType = gameType;
            DFSSite = dfsSite;
            Name = name;
        }

        #endregion

        #region Public Methods

        public static Slate Create(
            DateTime date,
            Sport sport,
            GameType gameType,
            DFSSite dfsSite,
            string name)
        {
            var newSlate = new Slate(new SlateID(), date, sport, gameType, dfsSite, name);
            newSlate.AddDomainEvent(new SlateCreatedEvent(newSlate));
            return newSlate;
        }

        #endregion
    }
}
