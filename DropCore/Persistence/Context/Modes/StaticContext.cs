namespace DropCore.Persistence.Context.Modes
{
    public class StaticContext<T> : IContext<T>
        where T : class
    {
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
