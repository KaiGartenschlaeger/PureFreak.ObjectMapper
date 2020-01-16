namespace PureFreak.ObjectMapper
{
    public interface IObjectConverter
    {
        void CopyProperties<TSource, TTarget>(TSource source, TTarget target);

        T Convert<T>(object source);
    }
}
