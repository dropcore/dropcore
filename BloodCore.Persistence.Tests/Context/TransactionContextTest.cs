using BloodCore.Persistence.Context;
using BloodCore.Persistence.Context.Modes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data;

namespace BloodCore.Persistence.Tests.Context
{
    [TestClass]
    public class TransactionContextTest
    {
        Mock<IDbTransaction> SessionMock { get; set; }
        Mock<IContext<IDbTransaction>> ContextMock { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            SessionMock = new Mock<IDbTransaction>();
            ContextMock = new Mock<IContext<IDbTransaction>>();
            TransactionContext.SetContext(ContextMock.Object);
        }

        [TestMethod]
        public void TransactionContext_Can_Get_Current()
        {
            var current = TransactionContext.Current;
            ContextMock.Verify(c => c.Current);
        }

        [TestMethod]
        public void TransactionContext_Can_Set_Context()
        {
            Assert.AreEqual(ContextMock.Object, TransactionContext.Context);
        }

        [TestMethod]
        public void TransactionContext_Can_Bind_Session_Instance()
        {
            TransactionContext.Bind(SessionMock.Object);
            ContextMock.Verify(c => c.Bind(SessionMock.Object));
        }

        [TestMethod]
        public void TransactionContext_Can_Unbind_Session_Instance()
        {
            TransactionContext.Unbind();
            ContextMock.Verify(c => c.Unbind());
        }
    }
}
