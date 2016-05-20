using System;
using System.Data;

namespace BloodCore.Persistence.Session
{
    public class SessionImpl : ISession
    {
        public IDbConnection Connection { get; private set; }

        public SessionImpl(IDbConnection connection)
        {
            Connection = connection;
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();

            Connection.Dispose();
        }

        public void Open()
        {
            if (Connection.State == ConnectionState.Open)
                throw new InvalidOperationException("Session is already opened.");

            if (Connection.State == ConnectionState.Broken)
                throw new InvalidOperationException("Session is broken, please close the session before opening it.");

            Connection.Open();
        }

        public void Close()
        {
            if (Connection.State == ConnectionState.Closed)
                throw new InvalidOperationException("Session is already closed.");

            Connection.Close();
        }
    }
}
