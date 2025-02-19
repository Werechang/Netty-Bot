﻿using Autofac;
using DiscordBot.Framework.Contract.Modularity;
using DiscordBot.Framework.Contract.TimedAction;

namespace DiscordBot.Modules.AutoRole;

internal class AutoRoleModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AutoRoleCommands>().As<IGuildModule>();
        builder.RegisterType<AutoRoleManager>().SingleInstance().AsSelf();
        builder.RegisterType<SetupAutoRolesTask>().As<ITimedAction>();
    }
}