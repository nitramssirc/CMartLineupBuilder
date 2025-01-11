using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

namespace Application.Commands.AddSalaries
{
    public class AddSalariesCommand : IRequestHandler<AddSalariesRequest, AddSalariesResponse>
    {
        #region Dependencies

        private readonly ICommandRepository<Slate, SlateID> _slateCommandRepository;
        private readonly ISpecificationFactory specificationFactory;

        #endregion

        #region Constructor

        public AddSalariesCommand(
            ICommandRepository<Slate, SlateID> slateCommandRepository,
            ISpecificationFactory specificationFactory)
        {
            _slateCommandRepository = slateCommandRepository;
            this.specificationFactory = specificationFactory;
        }

        #endregion

        #region IRequestHandler<AddSalariesRequest, AddSalariesResponse> Implementation

        public async Task<AddSalariesResponse> Handle(AddSalariesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //query for lookup data
                var slate = await LookupSlate(request.SlateID);

                //Loop through the salaries and add them to the slate
                foreach (var salary in request.Salaries)
                {
                    AddSalary(slate, salary);
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
            var specification = specificationFactory.Create<GetSlatesByDFSSiteAndSport>(id);
            var slate = await _slateCommandRepository.GetEntity(specification);
            return slate ?? throw new Exception("Slate not found");
        }

        private void AddSalary(Slate slate, SalaryData salary)
        {
            Salary constructSalary = ConstructSalary(slate, salary);
            slate.AddSalary(constructSalary);
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

        #endregion
    }
}
