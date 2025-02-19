using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.DataAccess.Contract.ReactionRoles
{
    public interface IReactionRoleBusinessLogic
    {
        Task<IEnumerable<ReactionRole>> RetrieveAllReactionRoleDatasAsync();
        Task SaveReactionRoleAsync(ReactionRole reactionRole);
        Task DeleteReactionRoleAsync(long reactionRoleId);
    }
}