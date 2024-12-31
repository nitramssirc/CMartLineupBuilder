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

        private List<Projection> _projections;
        public IReadOnlyCollection<Projection> Projections => _projections;

        private List<Salary> _salaries;
        public IReadOnlyCollection<Salary> Salaries => _salaries;

        #region Constructors

        private Player():base(new PlayerID())
        {
            _projections = new List<Projection>();
            _salaries = new List<Salary>();
        }

        private Player(
            PlayerID id,
            string firstName,
            string lastName,
            Sport sport) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Sport = sport;
            _projections = new List<Projection>();
            _salaries = new List<Salary>();
        }

        #endregion

        #region Factory Methods

        public static Player Create(
            string firstName,
            string lastName,
            Sport sport)
        {
            return new Player(new PlayerID(), firstName, lastName, sport);
        }

        public static Player Create(
            string name,
            Sport sport)
        {
            var splitName = name.Split(' ');
            var firstName = splitName[0];
            var lastName = string.Join(' ', splitName.Skip(1)) ;
            return new Player(new PlayerID(), firstName, lastName, sport);
        }


        #endregion

        #region Methods

        public void AddProjection(Projection projection)
        {
            _projections.Add(projection);
        }

        public void AddSalary(Salary salary)
        {
            var existingSalary = GetExistingSalaryForSlate(salary.SlateID);
            if (existingSalary != null)
            {
                _salaries.Remove(existingSalary);
            }
            _salaries.Add(salary);
        }

        #endregion

        #region Private Methods

        private Salary? GetExistingSalaryForSlate(SlateID slateID)
        {
            return _salaries.FirstOrDefault(s => s.SlateID == slateID);
        }

        #endregion
    }
}
