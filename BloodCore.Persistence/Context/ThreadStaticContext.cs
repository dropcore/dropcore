using System;

namespace BloodCore.Persistence.Context
{
    public class ThreadStaticContext<T> : IContext<T>
        where T : class
    {
        [ThreadStatic]
        private static T _instance;

        public T Current => _instance;

        public void Bind(T instance)
        {
            _instance = instance;
        }

        public T Unbind()
        {
            var instance = _instance;
            _instance = null;

            return instance;
        }
    }
}
