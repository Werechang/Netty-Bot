﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.DataAccess.Entities;
using DiscordBot.DataAccess.Modules.AutoRole.BusinessLogic;
using DiscordBot.DataAccess.NHibernate;
using NHibernate.Linq;

namespace DiscordBot.DataAccess.Modules.AutoRole.Repository;

internal class AutoRoleRepository : IAutoRoleRepository
{
    private readonly ISessionProvider _provider;

    public AutoRoleRepository(ISessionProvider provider)
    {
        _provider = provider;
    }

    public async Task<bool> CanCreateAutoRoleAsync(ulong guildId, ulong roleId)
    {
        using (var session = _provider.OpenSession())
        {
            var query = session.Query<AutoroleSetupEntity>()
                .Where(entity => entity.GuildId == guildId.ToString() && entity.RoleId == roleId.ToString());
            return !await query.AnyAsync();
        }
    }

    public async Task SaveSetupAsync(AutoRoleSetupData data)
    {
        using (var session = _provider.OpenSession())
        {
            var entity = new AutoroleSetupEntity
            {
                Id = data.Id,
                GuildId = data.GuildId,
                RoleId = data.RoleId
            };
            await session.SaveOrUpdateAsync(entity);
            await session.FlushAsync();
        }
    }

    public async Task<IEnumerable<AutoRoleSetupData>> RetrieveAllSetupsForGuildAsync(ulong guildId)
    {
        using (var session = _provider.OpenSession())
        {
            var query = session.Query<AutoroleSetupEntity>()
                .Where(entity => entity.GuildId == guildId.ToString());
            var entities = await query.ToListAsync();
            return entities.Select(MapEntityToData);
        }
    }

    public async Task DeleteSetupAsync(long autoRoleSetupId)
    {
        using (var session = _provider.OpenSession())
        {
            var entity = await session.LoadAsync<AutoroleSetupEntity>(autoRoleSetupId);
            await session.DeleteAsync(entity);
            await session.FlushAsync();
        }
    }

    public async Task<IEnumerable<AutoRoleSetupData>> RetrieveAllSetupsAsync()
    {
        using (var session = _provider.OpenSession())
        {
            var query = session.Query<AutoroleSetupEntity>();
            var entities = await query.ToListAsync();
            return entities.Select(MapEntityToData);
        }
    }

    private AutoRoleSetupData MapEntityToData(AutoroleSetupEntity entity)
    {
        return new AutoRoleSetupData(entity.Id, entity.GuildId, entity.RoleId);
    }
}