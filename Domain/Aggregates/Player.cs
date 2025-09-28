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
    public class Player : Entity, IAggregateRoot
    {
        #region Properties

        public Guid SlateID { get; private set; }

        public string Name { get; private set; }

        public Team Team { get; private set; }

        public Guid GameID { get; private set; }

        public Salary Salary { get; private set; }

        private readonly List<Projection> _projections = [];
        public IReadOnlyCollection<Projection> Projections => _projections;


        #endregion

        #region Constructor

        private Player(
            Guid playerID,
            Guid slateID,
            string name,
            Team team,
            Salary salary,
            Guid game) : base(playerID)
        {
            Salary = salary;
            GameID = game;
            SlateID = slateID;
            Name = name;
            Team = team;
        }

        #endregion

        #region Public Methods

        public static Player Create(
            string name,
            Team team,
            Salary salary,
            Game game)
        {
            var player = new Player(Guid.NewGuid(), game.SlateID, name, team, salary, game.Id);
            player.AddDomainEvent(new PlayerCreatedEvent(player));

            return player;
        }

        public void UpdateSalary(Salary newSalary)
        {
            Salary = newSalary;
            AddDomainEvent(new PlayerSalaryUpdatedEvent(Id, Name, Salary.SalaryAmount));
        }

        public void SetProjection(Projection projection)
        {
            _projections.RemoveAll(p => p.ProjectionSource == projection.ProjectionSource);
            _projections.Add(projection);
            AddDomainEvent(new PlayerProjectionsUpdatedEvent(Id, projection.ProjectionSource));
        }

        #endregion

    }
}
