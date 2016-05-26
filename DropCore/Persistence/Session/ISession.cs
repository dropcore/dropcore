using System;
using System.Data;

namespace DropCore.Persistence.Session
{
    public interface ISession : IDisposable
    {
        IDbConnection Connection { get; }
        void Open();
        void Close();
    }
}
