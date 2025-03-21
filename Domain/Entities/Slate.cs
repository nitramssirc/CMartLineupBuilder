﻿using Common.Enums;

using Domain.Common.Entities;
using Domain.Events;
using Domain.Events.SlateEvents;
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

        private readonly List<Game> _games = [];
        public IReadOnlyCollection<Game> Games => _games;

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

        public void AddSalary(Salary salary)
        {
            //Remove existing salary for player
            var existingSalaries = _salaries.Where(s => s.DFSSiteID == salary.DFSSiteID ).ToList();
            if(existingSalaries.Count == 0) 
            {
                _salaries.Add(salary);
                AddDomainEvent(new SalaryAddedToSlateEvent(this, salary));
            }
            foreach (var existingSalary in existingSalaries) {
                existingSalary.UpdateSalaryAmount(salary.SalaryAmount);
            }
            
        }

        public void AddProjection(Projection projection)
        {
            _projections.Add(projection);
            AddDomainEvent(new ProjectionAddedToSlateEvent(projection));
        }

        public void ClearProjectionsFromSource(ProjectionSource projectionSource)
        {
            var projectionsToRemove = _projections.Where(p => p.ProjectionSource == projectionSource).ToList();
            foreach (var projection in projectionsToRemove)
            {
                _projections.Remove(projection);
                AddDomainEvent(new ProjectionRemovedFromSlateEvent(projection));
            }
        }

        public void AddGame(Game game)
        {
            if(_games.Any(g => g.HomeTeam == game.HomeTeam && g.AwayTeam == game.AwayTeam))
            {
                return;
            }

            _games.Add(game);
            AddDomainEvent(new GameAddedToSlateEvent(this, game));
        }

        #endregion
    }
}
