using Discord;
using Discord.Commands;
using Discord.TestBot.Core.Commands;
using Discord.WebSocket;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Discord.TestBot
{
    class Program
    {

        private DiscordSocketClient client;
        private CommandService commands;

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            this.client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info
            });

            commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = false,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Info
            });


            client.MessageReceived += Client_MessageReceived;

            await commands.AddModulesAsync(Assembly.GetEntryAssembly());

            client.Ready += Client_Ready;

            client.Log += Client_Log;

            // TODO Enter Discord-Token!!!
            await client.LoginAsync(TokenType.Bot, "<Discord-Token>");
            await client.StartAsync();
            await Task.Delay(-1);
        }


        private async Task Client_Log(LogMessage arg)
        {
            
            await Task.Run(() => Console.WriteLine($"{DateTime.Now:dd.MM.yyyy hh:mm:ss}: [{arg.Source}] {arg.Message}"));
        }

        private async Task Client_Ready()
        {
            await client.SetGameAsync("Test Bot", "https://google.com", StreamType.NotStreaming);
        }

        private async Task Client_MessageReceived(SocketMessage messageParam)
        {

            var message = messageParam as SocketUserMessage;
            var context = new SocketCommandContext(client, message);


            if (message.Content == "--ping") await message.Channel.SendMessageAsync("pong!");


            if (context.Message == null || context.Message.Content == "") return;
            if (context.User.IsBot) return;

            int argumentPos = 0;
            if (!(message.HasStringPrefix("!", ref argumentPos) || message.HasMentionPrefix(client.CurrentUser, ref argumentPos))) return;
            
            var result = await commands.ExecuteAsync(context, argumentPos);
            if (!result.IsSuccess) await context.Channel.SendMessageAsync(result.ErrorReason);
            

        }

    }
}
