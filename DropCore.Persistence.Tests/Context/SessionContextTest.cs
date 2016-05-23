using DropCore.Persistence.Context;
using DropCore.Persistence.Context.Modes;
using DropCore.Persistence.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DropCore.Persistence.Tests.Context
{
    [TestClass]
    public class SessionContextTest
    {
        Mock<ISession> SessionMock { get; set; }
        Mock<IContext<ISession>> ContextMock { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            SessionMock = new Mock<ISession>();
            ContextMock = new Mock<IContext<ISession>>();
            SessionContext.SetContext(ContextMock.Object);
        }

        [TestMethod]
        public void SessionContext_Can_Get_Current()
        {
            var current = SessionContext.Current;
            ContextMock.Verify(c => c.Current);
        }

        [TestMethod]
        public void SessionContext_Can_Set_Context()
        {
            Assert.AreEqual(ContextMock.Object, SessionContext.Context);
        }

        [TestMethod]
        public void SessionContext_Can_Bind_Session_Instance()
        {
            SessionContext.Bind(SessionMock.Object);
            ContextMock.Verify(c => c.Bind(SessionMock.Object));
        }

        [TestMethod]
        public void SessionContext_Can_Unbind_Session_Instance()
        {
            SessionContext.Unbind();
            ContextMock.Verify(c => c.Unbind());
        }
    }
}
