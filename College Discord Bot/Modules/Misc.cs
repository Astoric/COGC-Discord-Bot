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

        [Command("test")]
        public async Task test()
        {
            await Context.Channel.SendMessageAsync("Test");
        }
    }
}
