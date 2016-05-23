using DropCore.Persistence.Context.Modes;
using DropCore.Persistence.Tests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DropCore.Persistence.Tests.Context.Modes
{
    [TestClass]
    public class StaticContextTest
    {

        [TestMethod]
        public void StaticContext_Can_Bind_Instance()
        {
            var instance = new ContextInstanceFixture();
            var context = new StaticContext<ContextInstanceFixture>();
            Assert.IsNull(context.Current);
            context.Bind(instance);
            Assert.IsNotNull(context.Current);
            Assert.AreEqual(instance, context.Current);
        }

        [TestMethod]
        public void StaticContext_Can_Unbind_Instance()
        {
            var instance = new ContextInstanceFixture();
            var context = new StaticContext<ContextInstanceFixture>();
            context.Bind(instance);
            Assert.IsNotNull(context.Current);
            var unboundInstance = context.Unbind();
            Assert.IsNull(context.Current);
            Assert.AreEqual(instance, unboundInstance);
        }
    }
}
