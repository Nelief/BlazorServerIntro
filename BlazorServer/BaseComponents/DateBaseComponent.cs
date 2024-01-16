using Microsoft.AspNetCore.Components;
using System;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorServer.BaseComponents
{
    public class DateBaseComponent:ComponentBase
    {
        public DateTime dateTime { get; set; }
        System.Timers.Timer dateTimer;

        public DateBaseComponent()
        {
            dateTimer = new System.Timers.Timer(1000)
            {
                Enabled = true,
                AutoReset = true
            };
            dateTimer.Elapsed += (sender, e) => Tick();
        }

        private void Tick()
        {
            dateTime = DateTime.Now;
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            dateTimer?.Dispose();
        }
    }
}
