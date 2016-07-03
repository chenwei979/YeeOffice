using System;
using System.Data;

namespace YeeOffice.Common.DataAccess
{
    public interface IDatabase : IDbConnection, IDisposable
    {
    }
}
