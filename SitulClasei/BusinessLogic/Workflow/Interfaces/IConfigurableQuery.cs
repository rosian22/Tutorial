using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SitulClasei.DataLayer.Interfaces;
using Models.Interfaces;

namespace SitulClasei.BusinessLogic.Workflow.Interfaces
{
    public interface IConfigurableQuery<TEntity, TModel> : IDisposable 
        where TEntity : class, IDataAccessObject
        where TModel : class, IModel
    {
        bool IsValid { get; }

        IOrderedConfigurableQuery<TEntity, TModel> OrderBy<TKey>(Expression<Func<TEntity, TKey>> expression);

        IOrderedConfigurableQuery<TEntity, TModel> OrderByDesc<TKey>(Expression<Func<TEntity, TKey>> expression);

        IConfigurableQuery<TEntity, TModel> Paginate(int pageNumber, int numberOfItemsPerPage);

        IList<TModel> Execute();

        Task<IList<TModel>> ExecuteAsync();
    }
}
