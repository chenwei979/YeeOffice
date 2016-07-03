using System;
using System.Data;

namespace Ak.Projects.Common.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabase Database { get; set; }
        IDbTransaction Transaction { get; set; }
        void SaveChanges();
    }
}
