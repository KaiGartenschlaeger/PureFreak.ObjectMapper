namespace PureFreak.ObjectMapper
{
    public interface IObjectConverter
    {
        void MapProperties<TSource, TTarget>(TSource source, TTarget target)
            where TSource : class
            where TTarget : class;

        T Convert<T>(object source)
            where T : class;
    }
}
