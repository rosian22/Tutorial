using System.Collections.Generic;
using System.Threading.Tasks;
using SitulClasei.DataLayer.Repositories;

namespace DataLayer.Implementation
{
    public class AspNetUserRepository : BaseRepository<AspNetUser>
    {
        protected override async Task<AspNetUser> FetchFromDbAsync(AspNetUser entity, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(user =>user.Id == entity.Id ,navigationProperties).ConfigureAwait(false);
        }

        protected override bool ValidateEntity(AspNetUser entity)
        {
            return entity != null;
        }
    }
}
