using Common.Enums;

using Domain.Common.Models;
using Domain.Slate.ValueTypes;

namespace Domain.Slate.Models
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

        private Slate(
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

        #region Factory Methods

        public static Slate Create(
            DateTime date, 
            Sport sport, 
            GameType gameType, 
            DFSSite dfsSite,
            string name)
        {
            return new Slate(new SlateID(), date, sport, gameType, dfsSite, name);
        }

        #endregion
    }
}
