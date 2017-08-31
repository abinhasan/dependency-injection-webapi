using System;
using System.Data;

namespace AjkerdealAdmin.Connection
{
    public interface IConnection :IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
