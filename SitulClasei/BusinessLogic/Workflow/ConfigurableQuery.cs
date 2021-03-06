﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SitulClasei.BusinessLogic.TypeManagement;
using SitulClasei.BusinessLogic.Workflow.Interfaces;
using SitulClasei.DataLayer.Interfaces;
using Models.Interfaces;

namespace SitulClasei.BusinessLogic.Workflow
{
    public class ConfigurableQuery<TEntity, TModel> : IConfigurableQuery<TEntity, TModel>
        where TEntity : class, IDataAccessObject
        where TModel : class, IModel
    {
        private readonly ClasaEntitiesDb mContext;
        private IQueryable<TEntity> mDbQuery;

        public ConfigurableQuery()
        {
        }

        public ConfigurableQuery(ClasaEntitiesDb context, IQueryable<TEntity> dbQuery)
        {
            mContext = context;
            mDbQuery = dbQuery;
        }

        public bool IsValid => mContext != null && mDbQuery != null;

        public IOrderedConfigurableQuery<TEntity, TModel> OrderBy<TKey>(Expression<Func<TEntity, TKey>> expression)
        {
            if (!IsValid)
            {
                return new OrderedConfigurableQuery<TEntity, TModel>();
            }

            return new OrderedConfigurableQuery<TEntity, TModel>(mContext, mDbQuery.OrderBy(expression));
        }

        public IOrderedConfigurableQuery<TEntity, TModel> OrderByDesc<TKey>(Expression<Func<TEntity, TKey>> expression)
        {
            if (!IsValid)
            {
                return new OrderedConfigurableQuery<TEntity, TModel>();
            }

            return new OrderedConfigurableQuery<TEntity, TModel>(mContext, mDbQuery.OrderByDescending(expression));
        }

        public IConfigurableQuery<TEntity, TModel> Paginate(int pageNumber, int numberOfItemsPerPage)
        {
            if (IsValid)
            {
                mDbQuery = mDbQuery.Skip(pageNumber * numberOfItemsPerPage).Take(numberOfItemsPerPage);
            }
            
            return this;
        }

        public IList<TModel> Execute()
        {
            return mDbQuery.ToList().CopyTo<TModel>();
        }

        public async Task<IList<TModel>> ExecuteAsync()
        {
            var result = await mDbQuery.ToListAsync().ConfigureAwait(false);
            return result.CopyTo<TModel>();
        }

        public void Dispose()
        {
            mContext?.Dispose();
        }
    }
}
