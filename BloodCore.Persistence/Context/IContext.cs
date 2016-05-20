namespace BloodCore.Persistence.Context
{
    public interface IContext<T> where T : class
    {
        T Current { get; }
        void Bind(T instance);
        T Unbind();
    }
}
