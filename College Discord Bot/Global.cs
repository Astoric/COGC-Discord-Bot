using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Discord_Bot
{
    internal static class Global
    {
        internal static DiscordSocketClient Client { get; set; }
        internal static CommandService commandService { get; set; }
        internal static Discord.Color embedColour = new Color(3, 196, 244);
    }
}
