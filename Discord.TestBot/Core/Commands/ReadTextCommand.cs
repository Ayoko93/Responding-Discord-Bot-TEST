using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace Discord.TestBot.Core.Commands
{
    public class ReadTextCommand : ModuleBase<SocketCommandContext>
    {
        [Command("announcement"), Alias("ann")]
        public async Task ExecuteAsync(string title, string content)
        {

            var footer = new EmbedFooterBuilder
            {
                Text = "Announcement"
            };

            var embed = new EmbedBuilder
            {
                Color = Color.Red,
                Description = content,
                Timestamp = DateTime.Now,
                Title = title,
                Footer = footer
            };

            await ReplyAsync("", false, embed);
        }



        [Command("rl-announcement"), Alias("ann")]
        public async Task ExecuteAsync(string when, string loginName, string password)
        {

            var embed = new EmbedBuilder
            {
                Color = Color.Red,
                Description = $"Am {when} wollen wir einen Wettkampf starten. Bitte registriert euch.\nLogin:{loginName}\n:Passwort:{password}",
                Title = "Rocket League Tournament",
                Footer = new EmbedFooterBuilder { Text = "Announcement" },
                Author = new EmbedAuthorBuilder { Name = Context.User.Username },
                Timestamp = DateTime.UtcNow
            };

            await ReplyAsync("", false, embed);

        }


    }
}
