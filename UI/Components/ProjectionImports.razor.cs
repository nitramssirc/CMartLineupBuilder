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

namespace UI.Components
{
    public partial class ProjectionImports
    {
        #region Dependencies

        [Inject] IFileReaderService FileReaderService { get; set; }
        [Inject] IImportProjectionCommand ImportProjectionCommand { get; set; }
        [Inject] IGetProjectionsQuery GetProjectionsQuery { get; set; }

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

        ElementReference _projectionFileUpload;
        RadzenDataGrid<RotoGrindersProjection> _projectionGrid;

        #endregion

        #region Internal Properties

        private string? LastUploadTime
        {
            get
            {
                return ImportedProjections?.ImportDateTime.ToString("MM/dd/yyyy hh:mm tt") ?? "Upload Projections";
            }
        }

        private RotoGrindersProjection[] RotoGrindersProjections
        {
            get
            {
                return ImportedProjections?.RotoGrindersProjections ?? new RotoGrindersProjection[0];
            }
        }

        private ImportedProjections ImportedProjections { get; set; }

        private bool IsLoading { get; set; }

        private Guid inputFileId = Guid.NewGuid();

        #endregion

        #region Component Overrides

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        #endregion

        #region Event Handlers

        async void ImportProjections()
        {
            Console.WriteLine("Importing projections");
            IsLoading = true;
            try
            {
                var files = await FileReaderService.CreateReference(_projectionFileUpload).EnumerateFilesAsync();
                if (files.Count() == 0) return;
                ImportedProjections = await ImportProjectionCommand.Execute(Week, files.First());
                await _projectionGrid.Reload();
                IsLoading = false;
                ResetFileInput();
                StateHasChanged();
            }
            finally
            {
                IsLoading = false;
            }
        }

        async Task LoadProjections()
        {
            if(Week == null) return;
            IsLoading = true;
            ImportedProjections = await GetProjectionsQuery.Execute(Week);
            await _projectionGrid.Reload();
            IsLoading = false;
            StateHasChanged();
        }

        #endregion

        #region Private Methods

        private void ResetFileInput()
        {
            inputFileId = Guid.NewGuid();
        }

        #endregion
    }
}