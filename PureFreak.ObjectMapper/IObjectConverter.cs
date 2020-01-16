namespace PureFreak.ObjectMapper
{
    public interface IObjectConverter
    {
        void MapProperties<TSource, TTarget>(TSource source, TTarget target);

        T Convert<T>(object source);
    }
}
