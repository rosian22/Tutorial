using System;
using SitulClasei.DataLayer.Repositories;
using DataLayer;

namespace SitulClasei.BusinessLogic.Workflow.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        T Repository<T>() where T : BaseDataRepository;

        void CommitTransaction();

        void RollbackTransaction();

        void FinalizeTransaction(bool isTransactionSuccessful);
    }
}
