using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Domain;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using UI;
using UI.Shared;
using Tewr.Blazor.FileReader;
using Application.Commands.ImportProjection;
using Domain.Projections;
using Application.Queries.GetProjections;
using Application.Queries.GetExpertPicks;
using Application.Monitors.Projections;

namespace UI.Components
{
    public partial class ExpertPicks
    {
        #region Dependencies

        [Inject] IGetExpertPicksQuery GetExpertPicksQuery { get; set; }
        [Inject] IProjectionsMonitor ProjectionMonitor { get; set; }

        #endregion

        #region Parameters

        private Week _week;
        [Parameter]
        public Week Week
        {
            get { return _week; }
            set
            {
                if (value == _week) return;
                _week = value;
                Task.Run(async () => await LoadProjections());
            }
        }


        #endregion

        #region Element References

        RadzenDataGrid<RotoGrindersProjection> _projectionGrid;

        #endregion

        #region Internal Properties

        private RotoGrindersProjection[] ExpertPicksProjections
        {
            get; set;
        }

        private bool IsLoading { get; set; }


        #endregion

        #region Component Overrides

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ProjectionMonitor.ProjectionsUpdated += ProjectionMonitor_ProjectionsUpdated;
        }

        #endregion

        #region Event Handlers

        async Task LoadProjections()
        {
            if (Week == null) return;
            IsLoading = true;
            ExpertPicksProjections = await GetExpertPicksQuery.Execute(Week);
            await _projectionGrid.Reload();
            IsLoading = false;
            StateHasChanged();
        }


        private async void ProjectionMonitor_ProjectionsUpdated(object? sender, EventArgs e)
        {
            await LoadProjections();
        }

        #endregion
    }
}