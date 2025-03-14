using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

namespace Application.Commands.AddSalaries
{
    public class AddSalariesHandler: IRequestHandler<AddSalariesCommand, AddSalariesResponse>
    {
        #region Dependencies

        private readonly ICommandRepository<Slate> _slateCommandRepository;
        private readonly ISpecificationFactory specificationFactory;

        #endregion

        #region Constructor

        public AddSalariesHandler(
            ICommandRepository<Slate> slateCommandRepository,
            ISpecificationFactory specificationFactory)
        {
            _slateCommandRepository = slateCommandRepository;
            this.specificationFactory = specificationFactory;
        }

        #endregion

        #region IRequestHandler<AddSalariesRequest, AddSalariesResponse> Implementation

        public async Task<AddSalariesResponse> Handle(AddSalariesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //query for lookup data
                var slate = await LookupSlate(request.SlateID);

                //Loop through the salaries and add them to the slate
                foreach (var salary in request.Salaries)
                {
                    AddSalary(slate, salary);
                    AddGame(slate, salary);
                }

                //Save the changes
                await _slateCommandRepository.SaveAsync();

                return new AddSalariesResponse();

            }
            catch (Exception ex)
            {
                return new AddSalariesResponse(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private async Task<Slate> LookupSlate(SlateID id)
        {
            var specification = specificationFactory.Create<GetSlateByIDWithSalariesAndGamesSpec>(id);
            var slate = await _slateCommandRepository.GetEntity(specification);
            return slate ?? throw new Exception("Slate not found");
        }

        private void AddSalary(Slate slate, SalaryData salary)
        {
            Salary constructSalary = ConstructSalary(slate, salary);
            slate.AddSalary(constructSalary);
        }

        private void AddGame(Slate slate, SalaryData salary)
        {
            Game constructGame = ConstructGame(slate, salary);
            slate.AddGame(constructGame);
        }


        private Salary ConstructSalary(Slate slate, SalaryData salary)
        {
            return Salary.Create(
                slate.Id,
                salary.PlayerName,
                salary.Position,
                salary.Team,
                salary.Salary,
                salary.SiteID
            );
        }

        private Game ConstructGame(Slate slate, SalaryData salary)
        {
            return Game.Create(
                slate.Id,
                Enum.Parse<Team>(salary.IsHomeTeam ? salary.Team : salary.Opponent),
                Enum.Parse<Team>(salary.IsHomeTeam ? salary.Opponent : salary.Team),
                TimeOnly.FromDateTime(salary.GameTime)
            );
        }

        #endregion
    }
}
