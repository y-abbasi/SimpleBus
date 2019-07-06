namespace SimpleBus.Config
{
    public interface IServiceProviderDecorator<T> : IServiceProvider<T>
    {
        void SeDecoratee(IServiceProvider<T> decoratee);
    }
}