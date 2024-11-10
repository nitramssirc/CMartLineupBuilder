using Application.Queries.GetSlates;

using Common.Enums;

using MediatR;

using Microsoft.AspNetCore.Components;

namespace UI.Components
{
    public partial class SlateSelector
    {
        #region Dependencies

        [Inject] IMediator Mediator { get; set; }

        [Inject] NavigationManager NavManager { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public Guid SelectedSlateID { get; set; }

        #endregion

        #region Internal Properties

        private List<GetSlateResponse> Slates { get; set; } = new List<GetSlateResponse>();
        private List<Sport> Sports { get; } = Enum.GetValues(typeof(Sport)).Cast<Sport>().ToList();

        private List<DFSSite> Sites { get; } = Enum.GetValues(typeof(DFSSite)).Cast<DFSSite>().ToList();

        private Sport SelectedSport { get; set; }

        private DFSSite SelectedSite { get; set; }


        #endregion

        #region Component Overrides

        protected override async Task OnInitializedAsync()
        {
            SelectedSport = Sport.NFL;
            SelectedSite = DFSSite.DraftKings;
            await LoadSlates();
        }

        #endregion

        #region Event Handlers

        private async Task OnSportChanged()
        {
            await LoadSlates();
        }

        private async Task OnSiteChanged()
        {
            await LoadSlates();
        }

        private async Task OnSlateChanged()
        {
            //Invoke slate changed event
        }

        private async Task OnAddSlateClick()
        {
            NavManager.NavigateTo("/addSlate");
        }

        #endregion

        #region Private Methods

        private async Task LoadSlates()
        {
            var request = new GetSlateRequest(SelectedSite.ToString(), SelectedSport.ToString());
            Slates = await Mediator.Send(request);
        }

        #endregion
    }
}