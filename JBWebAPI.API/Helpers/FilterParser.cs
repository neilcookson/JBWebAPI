using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JBWebAPI.API.Helpers
{
    public class FilterParser<T> : IFilterParser<T> where T : class
    {
        private Type type = typeof(T);
        Dictionary<string, PropertyInfo> _filterMaps;
        public Dictionary<string, PropertyInfo> FilterMaps
        {
            get
            {
                if (!_filterMaps?.Any() ?? true)
                {
                    _filterMaps = GetAllFilters();
                }
                return _filterMaps;
            }
        }

        public Func<T, bool> GetFilter(string rawFilter)
        {
            FilterModel filterModel = ParseRawFilter(rawFilter);
            var matchingDictionaryEntry = FilterMaps?.Where(entry => entry.Key == filterModel.FilterOn)?.FirstOrDefault();
            var matchingProp = matchingDictionaryEntry?.Value;
            return new Func<T, bool>(t => matchingProp.GetValue(t).ToString().ToLower().Contains(filterModel.Value.ToLower()));
        }

        private Dictionary<string, PropertyInfo> GetAllFilters()
        {
            var stringProps = type.GetProperties()?.Where(prop => prop.PropertyType == typeof(string));
            var propNames = stringProps.Select(prop => prop.Name);
            return propNames.Zip(stringProps, (k, v) => new { k, v }).ToDictionary(obj => obj.k, obj => obj.v);
        }

        private FilterModel ParseRawFilter(string rawFilter)
        {
            var splitFilter = rawFilter.Split(':');
            return new FilterModel()
            {
                FilterOn = splitFilter.FirstOrDefault(),
                Value = splitFilter.LastOrDefault()
            };
        }

        private class FilterModel
        {
            public string FilterOn { get; set; }
            public string Value { get; set; }
        }

    }
}