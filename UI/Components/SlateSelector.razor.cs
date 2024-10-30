namespace UI.Components
{
    public partial class SlateSelector
    {
        //#region Dependencies
        ////[Inject] IAddWeekCommand AddWeekCommand { get; set; }

        ////[Inject] IGetWeeksQuery GetWeeksQuery { get; set; }

        //[Inject] NavigationManager NavManager { get; set; }

        //#endregion

        //#region Parameters

        //[Parameter]
        //public Week SelectedWeek
        //{
        //    get
        //    {
        //        return Weeks.FirstOrDefault(w => w.ID == SelectedWeekID);
        //    }
        //    set
        //    {
        //        SelectedWeekID = value.ID;
        //    }
        //}

        //[Parameter]
        //public EventCallback<Week> OnWeekChanged { get; set; }

        //#endregion

        //#region Internal Properties
        //private Week[] Weeks { get; set; }
        //private int SelectedWeekID { get; set; }

        //#endregion
        //#region Component Overrides
        //protected override async Task OnInitializedAsync()
        //{
        //    Weeks = await GetWeeksQuery.Execute();
        //    if (Weeks.Length > 0)
        //    {
        //        SelectedWeekID = Weeks.Last().ID;
        //    }
        //    OnSelectedWeekChanged();
        //}

        //#endregion
        //#region Event Handlers
        //private async void OnAddWeekClick()
        //{
        //    NavManager.NavigateTo("/addweek");
        //}

        //private void OnSelectedWeekChanged()
        //{
        //    OnWeekChanged.InvokeAsync(SelectedWeek);
        //}
        //#endregion
    }
}