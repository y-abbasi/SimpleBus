namespace SimpleBus.Config
{
    public interface IServiceProvider<out T>
    {
        T Provide();

    }
}