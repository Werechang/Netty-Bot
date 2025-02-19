﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.DataAccess.Contract.YoutubeNotification;

public interface IYoutubeNotificationBusinessLogic
{
    Task<bool> IsStreamerInGuildAlreadyRegisteredAsync(string youtubeChannelId, ulong guildId);
    Task<long> SaveRegistrationAsync(YoutubeNotificationRegistration registration);
    Task DeleteRegistrationAsync(string youtubeChannelId, ulong guildId);
    Task<IEnumerable<YoutubeNotificationRegistration>> RetrieveAllRegistrationsAsync();
}