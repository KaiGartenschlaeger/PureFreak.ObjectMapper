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

        private void CopyPropertiesInternal(object source, object target)
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();

            var matchingProperties = GetMatchingProperties(sourceType, targetType);
            foreach (var match in matchingProperties)
            {
                var value = match.SourceProperty.GetValue(source);
                match.TargetProperty.SetValue(target, value);
            }
        }

        public void MapProperties<TSource, TTarget>(TSource source, TTarget target)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            CopyPropertiesInternal(source, target);
        }

        public T Convert<T>(object source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var target = Activator.CreateInstance<T>();
            CopyPropertiesInternal(source, target);

            return target;
        }
    }
}
