using Common.Enums;

using Domain.Common.Entities;
using Domain.Events;
using Domain.ValueTypes;

namespace Domain.Entities
{
    public class Slate : Entity<SlateID>, IAggregateRoot
    {
        #region Properties

        public DateTime Date { get; private set; }

        public Sport Sport { get; private set; }

        public GameType GameType { get; private set; }

        public DFSSite DFSSite { get; private set; }

        public string Name { get; private set; } = string.Empty;

        private readonly List<Projection> _projections = [];
        public IReadOnlyCollection<Projection> Projections => _projections;

        private readonly List<Salary> _salaries = [];
        public IReadOnlyCollection<Salary> Salaries => _salaries;

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

        public void AddSalary(Salary salary)
        {
            _salaries.Add(salary);
            AddDomainEvent(new SalaryAddedToSlateEvent(this, salary));
        }

        #endregion
    }
}
