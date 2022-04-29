using Autofac;
using DiscordBot.Modules.AutoMod;
using DiscordBot.Modules.AutoRole;
using DiscordBot.Modules.Basics;
using DiscordBot.Modules.BirthdayList;
using DiscordBot.Modules.Huebcraft;
using DiscordBot.Modules.MusicPlayer;
using DiscordBot.Modules.ReactionRoles;
using DiscordBot.Modules.TwitchNotifications;
using DiscordBot.Modules.YoutubeNotifications;
using DiscordBot.Modules.ZenQuote;

namespace DiscordBot.Modules;

public class DiscordBotModulesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<HuebcraftModule>();
        builder.RegisterModule<BasicModule>();
        builder.RegisterModule<ReactionRolesModule>();
        builder.RegisterModule<ZenQuoteModule>();
        builder.RegisterModule<BirthdayListModule>();
        builder.RegisterModule<MusicPlayerModule>();
        builder.RegisterModule<TwitchNotificationsModule>();
        builder.RegisterModule<YoutubeNotificationsModule>();
        builder.RegisterModule<AutoRoleModule>();
        builder.RegisterModule<AutoModModule>();
    }
}