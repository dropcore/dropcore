using BloodCore.Persistence.Context;
using BloodCore.Persistence.Context.Modes;
using BloodCore.Persistence.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BloodCore.Persistence.Tests.Context
{
    [TestClass]
    public class SessionFactoryContextTest
    {
        Mock<ISessionFactory> SessionFactoryMock { get; set; }
        Mock<IContext<ISessionFactory>> ContextMock { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            SessionFactoryMock = new Mock<ISessionFactory>();
            ContextMock = new Mock<IContext<ISessionFactory>>();
            SessionFactoryContext.SetContext(ContextMock.Object);
        }

        [TestMethod]
        public void SessionContext_Can_Get_Current()
        {
            var current = SessionFactoryContext.Current;
            ContextMock.Verify(c => c.Current);
        }

        [TestMethod]
        public void SessionFactoryContext_Can_Set_Context()
        {
            Assert.AreEqual(ContextMock.Object, SessionFactoryContext.Context);
        }

        [TestMethod]
        public void SessionFactoryContext_Can_Bind_Session_Instance()
        {
            SessionFactoryContext.Bind(SessionFactoryMock.Object);
            ContextMock.Verify(c => c.Bind(SessionFactoryMock.Object));
        }

        [TestMethod]
        public void SessionFactoryContext_Can_Unbind_Session_Instance()
        {
            SessionFactoryContext.Unbind();
            ContextMock.Verify(c => c.Unbind());
        }
    }
}
