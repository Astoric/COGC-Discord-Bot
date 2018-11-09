using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace College_Discord_Bot.Core
{
    internal static class RepeatingTimer
    {
        private static Timer loopingTimer;

        internal static Task StartTimer()
        {

            OnStartUp();

            loopingTimer = new Timer()
            {
                Interval = 10000,
                AutoReset = true,
                Enabled = true
            };
            loopingTimer.Elapsed += OnTimerTicked;

            return Task.CompletedTask;
        }

        private static async void OnStartUp()
        {
        }

        private static async void OnTimerTicked(object sender, ElapsedEventArgs e)
        {
        }
    }
}