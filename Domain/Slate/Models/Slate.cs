using Common.Enums;

using Domain.Common.Models;

namespace Domain.Slate.Models
{
    public class Slate : AggregateRoot
    {
        #region Properties

        public DateTime Date { get; }

        public Sport Sport { get; }

        public GameType GameType { get; }

        public DFSSite DFSSite { get; }

        #endregion

        #region Constructors

        private Slate(DateTime date, Sport sport, GameType gameType, DFSSite dfsSite)
        {
            Date = date;
            Sport = sport;
            GameType = gameType;
            DFSSite = dfsSite;
        }

        #endregion

        #region Factory Methods

        public static Slate Create(DateTime date, Sport sport, GameType gameType, DFSSite dfsSite)
        {
            return new Slate(date, sport, gameType, dfsSite);
        }

        #endregion
    }
}
