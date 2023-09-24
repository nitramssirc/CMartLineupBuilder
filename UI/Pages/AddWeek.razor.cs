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
using Radzen.Blazor;
using UI;
using UI.Shared;
using Application.Commands.AddWeek;

namespace UI.Pages
{
    public partial class AddWeek
    {
        [Inject] IAddWeekCommand AddWeekCommand { get; set; }
        [Inject] private NavigationManager NavManager { get; set; }


        int WeekNumber { get; set; }

        DateTime WeekDate { get; set; } = DateTime.Now.Date;

        async Task OnAddWeekClick()
        {
            await AddWeekCommand.Execute(WeekNumber, WeekDate);
            NavManager.NavigateTo("/");
        }
    }
}