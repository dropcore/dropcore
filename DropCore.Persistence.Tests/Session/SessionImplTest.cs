using DropCore.Persistence.Session;
using DropCore.Persistence.Tests.Fixtures;
using DropCore.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace DropCore.Persistence.Tests.Session
{
    [TestClass]
    public class SessionImplTest : UnitTest
    {
        [TestMethod]
        public void SessionImpl_Can_Be_Opened()
        {
            var fixture = new PersistenceAdapterFixture();
            fixture.ConnectionMock.Setup(c => c.State).Returns(ConnectionState.Closed);

            using (var session = new SessionImpl(fixture.Connection))
                session.Open();

            fixture.ConnectionMock.Verify(c => c.Open());
        }

        [TestMethod]
        public void SessionImpl_Raises_OperationInvalidException_If_Connection_Has_Already_Been_Opened_On_Open()
        {
            var fixture = new PersistenceAdapterFixture();
            fixture.ConnectionMock.Setup(c => c.State).Returns(ConnectionState.Open);

            using (var session = new SessionImpl(fixture.Connection))
                AssertRaise<InvalidOperationException>(() => { session.Open(); });
        }

        [TestMethod]
        public void SessionImpl_Raises_OperationInvalidException_If_Connection_Is_Broken_On_Open()
        {
            var fixture = new PersistenceAdapterFixture();
            fixture.ConnectionMock.Setup(c => c.State).Returns(ConnectionState.Broken);

            using (var session = new SessionImpl(fixture.Connection))
                AssertRaise<InvalidOperationException>(() => { session.Open(); });
        }

        [TestMethod]
        public void SessionImpl_Can_Be_Closed()
        {
            var fixture = new PersistenceAdapterFixture();
            fixture.ConnectionMock.Setup(c => c.State).Returns(ConnectionState.Open);

            using (var session = new SessionImpl(fixture.Connection))
                session.Close();

            fixture.ConnectionMock.Verify(c => c.Close());
        }

        [TestMethod]
        public void SessionImpl_Raises_InvalidOperationException_If_Connection_Is_Closed_On_Close()
        {
            var fixture = new PersistenceAdapterFixture();
            fixture.ConnectionMock.Setup(c => c.State).Returns(ConnectionState.Closed);

            using (var session = new SessionImpl(fixture.Connection))
                AssertRaise<InvalidOperationException>(() => { session.Close(); });
        }

        [TestMethod]
        public void SessionImpl_Disposes_Connection_On_Dispose()
        {
            var fixture = new PersistenceAdapterFixture();
            var session = new SessionImpl(fixture.Connection);
            session.Dispose();

            fixture.ConnectionMock.Verify(c => c.Dispose());
        }
    }
}
