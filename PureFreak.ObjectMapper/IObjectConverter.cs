namespace PureFreak.ObjectMapper
{
    public interface IObjectConverter
    {
        void CopyPropeties<TSource, TTarget>(TSource source, TTarget target);

        T Convert<T>(object source);
    }
}
