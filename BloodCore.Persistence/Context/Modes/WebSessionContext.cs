using System.Web;

namespace BloodCore.Persistence.Context.Modes
{
    public class WebSessionContext<T> : IContext<T>
        where T : class
    {
        public T Current
        {
            get
            {
                return HttpContext.Current.Items[Key] as T;
            }
            private set
            {
                HttpContext.Current.Items[Key] = value;
            }
        }

        string Key => "Persistence.Context." + typeof(T).FullName;

        public void Bind(T instance)
        {
            Current = instance;
        }

        public T Unbind()
        {
            var instance = Current;
            Current = null;

            return instance;
        }
    }
}
