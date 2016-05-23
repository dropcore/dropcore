using DropCore.Persistence.Adapter;
using Moq;
using System.Data;

namespace DropCore.Persistence.Tests.Fixtures
{
    class PersistenceAdapterFixture
    {
        public Mock<IDbConnection> ConnectionMock { get; private set; }
        public Mock<IPersistenceAdapter> PersistenceAdapterMock { get; private set; }
        public IDbConnection Connection => ConnectionMock.Object;
        public IPersistenceAdapter PersistenceAdapter => PersistenceAdapterMock.Object;

        public PersistenceAdapterFixture()
        {
            ConnectionMock = new Mock<IDbConnection>();
            PersistenceAdapterMock = new Mock<IPersistenceAdapter>();
            PersistenceAdapterMock.Setup(pa => pa.Create("test")).Returns(Connection);
        }
    }
}
