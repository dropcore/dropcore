using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BloodCore.Persistence.Tests
{
    public abstract class UnitTest
    {
        protected static void AssertRaise<TException>(Action action)
            where TException : Exception
        {
            var raised = false;
            try
            {
                action?.Invoke();
            }
            catch (TException)
            {
                raised = true;
            }

            Assert.IsTrue(raised, $"Expected '{typeof(TException).FullName}' to be raised.");
        }
    }
}
