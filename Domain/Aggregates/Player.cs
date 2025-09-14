using Common.Enums;

using Domain.Common.Entities;
using Domain.Events.PlayerEvents;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Player : Entity<PlayerID>, IAggregateRoot
    {
        #region Properties

        public SlateID SlateID => Id.SlateID;

        public Salary Salary { get; private set; }

        public GameID GameID { get; private set; }

        private readonly List<Projection> _projections = [];
        public IReadOnlyCollection<Projection> Projections => _projections;

        public string Name => Id.Name;

        public Team Team => Id.Team;

        #endregion

        #region Constructor

        internal Player(
            SlateID slateID,
            string name,
            Team team,
            Salary salary,
            GameID game) : base(new PlayerID(slateID, name, team))
        {
            Salary = salary;
            GameID = game;
        }

        #endregion

        #region Public Methods

        public static Player Create(
            string name,
            Team team,
            Salary salary,
            Game game)
        {
            var player = new Player(game.SlateID, name, team, salary, game.Id);
            player.AddDomainEvent(new PlayerCreatedEvent(player.Id));

            return player;
        }

        public void UpdateSalary(Salary newSalary)
        {
            Salary = newSalary;
            AddDomainEvent(new PlayerSalaryUpdatedEvent(Id, Salary.SalaryAmount));
        }

        public void SetProjections(IEnumerable<Projection> projections)
        {
            _projections.Clear();
            _projections.AddRange(projections);
            AddDomainEvent(new PlayerProjectionsUpdatedEvent(Id));
        }

        #endregion

    }
}
