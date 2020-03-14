namespace Tour.Domain.Interfaces
{
    public interface IObjectMapper
    {
        TDestination Map<TDestination>(object source);

    }
}