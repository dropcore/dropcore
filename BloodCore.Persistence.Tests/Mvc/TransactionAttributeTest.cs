using BloodCore.Persistence.Context;
using BloodCore.Persistence.Context.Modes;
using BloodCore.Persistence.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data;
using System.Web.Mvc;

namespace BloodCore.Persistence.Tests.Mvc
{
    [TestClass]
    public class TransactionAttributeTest
    {
        private Mock<IDbConnection> ConnectionMock { get; set; }
        private Mock<IDbTransaction> TransactionMock { get; set; }
        private Mock<IContext<IDbTransaction>> ContextMock { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            ContextMock = new Mock<IContext<IDbTransaction>>();
            ConnectionMock = new Mock<IDbConnection>();
            TransactionMock = new Mock<IDbTransaction>();

            ConnectionMock.Setup(c => c.BeginTransaction()).Returns(TransactionMock.Object);
            ConnectionMock.Setup(c => c.BeginTransaction(IsolationLevel.Snapshot)).Returns(TransactionMock.Object);

            TransactionContext.SetContext(ContextMock.Object);
        }

        [TestMethod]
        public void TransactionAttribute_Begins_Transaction_On_Action_Executing_With_No_Isolation_Level()
        {
            var attr = new TransactionAttribute { Connection = ConnectionMock.Object };
            attr.OnActionExecuting(new ActionExecutingContext());

            ConnectionMock.Verify(c => c.BeginTransaction());
            ContextMock.Verify(cx => cx.Bind(TransactionMock.Object));
        }

        [TestMethod]
        public void TransactionAttribute_Begins_Transaction_With_Specified_Isolation_Level()
        {
            var attr = new TransactionAttribute { Connection = ConnectionMock.Object, IsolationLevel = IsolationLevel.Snapshot };
            attr.OnActionExecuting(new ActionExecutingContext());

            ConnectionMock.Verify(c => c.BeginTransaction(IsolationLevel.Snapshot));
            ContextMock.Verify(cx => cx.Bind(TransactionMock.Object));
        }
    }
}
