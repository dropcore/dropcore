using DropCore.Persistence.Session;
using DropCore.Persistence.Tests.Fixtures;
using DropCore.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DropCore.Persistence.Tests.Session
{
    [TestClass]
    public class SessionFactoryImplTest : UnitTest
    {
        [TestMethod]
        public void SessionFactoryImpl_Can_Set_Connection_String()
        {
            var factory = new SessionFactoryImpl();
            Assert.IsNull(factory.ConnectionString);

            Assert.AreEqual(factory, factory.SetConnectionString("test"));
            Assert.AreEqual("test", factory.ConnectionString);
        }

        [TestMethod]
        public void SessionFactoryImpl_Can_Set_Persistence_Adapter()
        {
            var fixture = new PersistenceAdapterFixture();
            var factory = new SessionFactoryImpl();
            Assert.IsNull(factory.Adapter);

            Assert.AreEqual(factory, factory.SetAdapter(fixture.PersistenceAdapter));
            Assert.AreEqual(fixture.PersistenceAdapter, factory.Adapter);
        }

        [TestMethod]
        public void SessionFactoryImpl_Can_Open_Session()
        {
            var fixture = new PersistenceAdapterFixture();
            var session = new SessionFactoryImpl()
                .SetConnectionString("test")
                .SetAdapter(fixture.PersistenceAdapter)
                .OpenSession();

            Assert.IsNotNull(session);
            Assert.AreEqual(fixture.Connection, session.Connection);
        }

        [TestMethod]
        public void SessionFactoryImpl_Raises_InvalidOperationException_When_Opening_Session_Without_Persistence_Adapter()
        {
            AssertRaise<InvalidOperationException>(() =>
            {
                new SessionFactoryImpl()
                    .OpenSession();
            });
        }
    }
}
