namespace PureFreak.ObjectMapper
{
    public interface IObjectConverter
    {
        /// <summary>
        /// Copies all property values from source to target where the name and type matches.
        /// </summary>
        /// <typeparam name="TSource">Type of source object containing the property values to copy.</typeparam>
        /// <typeparam name="TTarget">Type of the target object.</typeparam>
        /// <param name="source">Source object instance.</param>
        /// <param name="target">Target object instance.</param>
        /// <exception cref="System.ArgumentNullException">Raised if source or target is null.</exception>
        void MapProperties<TSource, TTarget>(TSource source, TTarget target)
            where TSource : class
            where TTarget : class;

        /// <summary>
        /// Converts the source object to the target object.
        /// </summary>
        /// <typeparam name="T">Type of the source.</typeparam>
        /// <param name="source">Source object instance to convert.</param>
        /// <returns>Returns the converted object or null if source contains null.</returns>
        T Convert<T>(object source)
            where T : class;
    }
}
