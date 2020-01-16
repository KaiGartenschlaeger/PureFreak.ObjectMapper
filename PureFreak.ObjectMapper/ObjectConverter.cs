using System;
using System.Collections.Generic;
using System.Linq;

namespace PureFreak.ObjectMapper
{
    public class ObjectConverter : IObjectConverter
    {
        private IList<PropertyMap> GetMatchingProperties(Type sourceType, Type targetType)
        {
            var sourceProperties = sourceType.GetProperties();
            var targetProperties = targetType.GetProperties();

            var properties = (from s in sourceProperties
                              from t in targetProperties
                              where s.Name == t.Name &&
                                    s.CanRead &&
                                    t.CanWrite &&
                                    s.PropertyType == t.PropertyType
                              select new PropertyMap
                              {
                                  SourceProperty = s,
                                  TargetProperty = t
                              }).ToList();

            return properties;
        }

        public void CopyPropeties<TSource, TTarget>(TSource source, TTarget target)
        {
            throw new System.NotImplementedException();
        }

        public T Convert<T>(object source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var sourceType = source.GetType();
            var targetType = typeof(T);

            var matchingProperties = GetMatchingProperties(sourceType, targetType);

            var result = Activator.CreateInstance<T>();

            foreach (var match in matchingProperties)
            {
                var value = match.SourceProperty.GetValue(source);
                match.TargetProperty.SetValue(result, value);
            }

            return result;
        }
    }
}
