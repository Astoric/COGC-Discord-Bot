using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Discord_Bot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {

        [Command("info")]
        public async Task info()
        {
            var embed = new EmbedBuilder();
            embed.AddField("Language:", "C#");
            embed.AddField("Library:", "Discord.net");
            embed.AddField("Documentation:", "https://discord.foxbot.me/latest/api/index.html");
            embed.AddField("Github:", "https://github.com/Astoric/COGC-Discord-Bot");
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
