namespace PureFreak.ObjectMapper
{
    public interface IObjectMapper
    {
        T Map<T>(object source);

        void MapProperties<TSource, TTarget>(TSource source, TTarget target);
    }
}
