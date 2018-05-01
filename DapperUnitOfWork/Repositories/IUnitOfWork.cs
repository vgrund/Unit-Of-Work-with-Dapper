using System;
using System.Data;

namespace DapperUnitOfWork.Repositories
{
    public interface IUnitOfWork
    {
        Guid Id { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}
