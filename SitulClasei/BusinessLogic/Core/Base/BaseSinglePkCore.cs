using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SitulClasei.BusinessLogic.TypeManagement;
using SitulClasei.BusinessLogic.Workflow;
using SitulClasei.DataLayer.Interfaces;
using SitulClasei.DataLayer.Repositories;
using Models.Interfaces;

namespace SitulClasei.BusinessLogic.Core.Base
{
    public abstract class BaseSinglePkCore<TRepo, TModel, TEntity> : BaseCore<TRepo, TModel, TEntity>
        where TRepo : BaseSinglePkRepository<TEntity>
        where TEntity : class, ISinglePkDataAccessObject, new()
        where TModel : class, ISinglePkModel, new()
    {
        public static async Task<TModel> GetAsync(Guid id, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAsync(id, navigationProperties).ConfigureAwait(false);

                return entities.CopyTo<TModel>();
            }
        }

        public static async Task DeleteAsync(Guid id)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                await repository.DeleteAsync(id).ConfigureAwait(false);
            }
        }
    }
}