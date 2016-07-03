using System;
using System.Data;

namespace Ak.Projects.Common.DataAccess
{
    public interface IDatabase : IDbConnection, IDisposable
    {
    }
}
