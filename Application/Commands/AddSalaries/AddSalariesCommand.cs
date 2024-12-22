using Application.Common.Repositories;

using Common.Enums;

using Domain.SlateAggregate.Models;
using Domain.SlateAggregate.ValueTypes;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddSalaries
{
    public class AddSalariesCommand : IRequestHandler<AddSalariesRequest, AddSalariesResponse>
    {
        #region Dependencies

        private readonly IQueryRepository<Player, PlayerID> _playerQueryRepository;
        private readonly IQueryRepository<Slate, SlateID> _slateQueryRepository;
        private readonly ICommandRepository<Player, PlayerID> _commandRepository;

        #endregion

        #region Constructor

        public AddSalariesCommand(
            IQueryRepository<Player, PlayerID> queryRepository,
            IQueryRepository<Slate, SlateID> slateQueryRepository,
            ICommandRepository<Player, PlayerID> commandRepository)
        {
            _playerQueryRepository = queryRepository;
            _slateQueryRepository = slateQueryRepository;
            _commandRepository = commandRepository;
        }

        #endregion

        #region IRequestHandler<AddSalariesRequest, AddSalariesResponse> Implementation

        public async Task<AddSalariesResponse> Handle(AddSalariesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //query for lookup data
                var queriedPlayers = await _playerQueryRepository.GetAllAsync();
                var slate = await LookupSlate(request.SlateID);

                //Loop through the salaries and add them to the players
                foreach (var salary in request.Salaries)
                {
                    var player = queriedPlayers.FirstOrDefault(p => salary.PlayerName == $"{p.FirstName} {p.LastName}");
                    await AddSalary(slate, player, salary);
                }

                //Save the changes
                await _commandRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                return new AddSalariesResponse(ex.Message);
            }

            return new AddSalariesResponse();
        }

        #endregion

        #region Private Methods

        private async Task<Slate> LookupSlate(SlateID id)
        {
            var slate = await _slateQueryRepository.GetByIdAsync(id);
            return slate == null ? throw new Exception("Slate not found") : slate;
        }

        private async Task AddSalary(Slate slate, Player? queryPlayer, SalaryData salary)
        {
            Player commandPlayer = await GetOrCreatePlayer(slate, queryPlayer, salary);
            Salary constructSalary = ConstructSalary(slate, commandPlayer, salary);
            commandPlayer.AddSalary(constructSalary);
        }

        private async Task<Player> GetOrCreatePlayer(Slate slate, Player? queryPlayer, SalaryData salary)
        {
            if (queryPlayer == null)
            {
                return await CreatePlayer(salary.PlayerName, slate.Sport);
            }

            return await LookUpPlayer(queryPlayer.Id);
        }

        private async Task<Player> LookUpPlayer(PlayerID id)
        {
            var lookedUpPlayer = await _commandRepository.GetByIdAsync(id);
            return lookedUpPlayer == null ? throw new Exception("Player not found") : lookedUpPlayer;
        }

        private async Task<Player> CreatePlayer(string name, Sport sport)
        {
            var createdPlayer = Player.Create(name, sport);
            await _commandRepository.AddAsync(createdPlayer);
            return createdPlayer;
        }
        private Salary ConstructSalary(Slate slate, Player commandPlayer, SalaryData salary)
        {
            return Salary.Create(
                slate.Id,
                commandPlayer.Id,
                salary.Position,
                salary.Team,
                salary.Salary,
                salary.SiteID
            );
        }

        #endregion
    }
}
