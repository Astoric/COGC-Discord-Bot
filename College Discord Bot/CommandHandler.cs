using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Discord;
using Discord.Rest;
using System.Net.Http;
using College_Discord_Bot.Core.UserAccounts;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using College_Discord_Bot.Modules;

namespace College_Discord_Bot
{
    class CommandHandler
    {

        DiscordSocketClient _client;
        CommandService _service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            Global.commandService = _service;
            await _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            if (context.User.IsBot) return;
            int argPos = 0;

            if ((msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos) && (context.Guild == null || context.Guild.Id != 377879473158356992)) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);
                if (result.Error != null)
                    switch (result.Error)
                    {
                        case CommandError.UnmetPrecondition:
                            var permissions = ((SocketGuildChannel)context.Channel).Guild.CurrentUser.GuildPermissions;
                            if (!string.IsNullOrWhiteSpace(result.ErrorReason) && permissions.SendMessages)
                            {
                                var embed = new EmbedBuilder();
                                embed.WithAuthor(context.User);
                                embed.WithDescription(result.ErrorReason);
                                embed.WithColor(new Color(3, 196, 244));
                                await context.Channel.SendMessageAsync("", false, embed.Build());
                            }
                            break;
                        case CommandError.UnknownCommand:
                            await context.Channel.SendMessageAsync("Unknown Command! To get a full command list, please use !help");
                            break;
                        case CommandError.BadArgCount:
                            await context.Channel.SendMessageAsync("Too few parameters! Please use !help to see how to use commands!");
                            break;
                        default:
                            Console.WriteLine(result.ErrorReason);
                            break;
                    }
            }
        }
    }
}