/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Extensions
/// 文件名称	：IQueryable.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/9 17:02:24 
/// 邮箱		：786744873@qq.com
/// 个人主站	：https://www.cnblogs.com/wyt007/
///
/// 功能描述	：
/// 使用说明	：
/// =================================
/// 修改者	：
/// 修改日期	：
/// 修改内容	：
/// =================================
///
/// ***********************************************************************


using BlogDemo.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BlogDemo.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy, IPropertyMapping propertyMapping)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (propertyMapping == null)
            {
                throw new ArgumentNullException(nameof(propertyMapping));
            }

            var mappingDictionary = propertyMapping.MappingDictionary;
            if (mappingDictionary == null)
            {
                throw new ArgumentNullException(nameof(mappingDictionary));
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            var orderByAfterSplit = orderBy.Split(',');
            foreach (var orderByClause in orderByAfterSplit.Reverse())
            {
                var trimmedOrderByClause = orderByClause.Trim();
                var orderDescending = trimmedOrderByClause.EndsWith(" desc");
                var indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ", StringComparison.Ordinal);
                var propertyName = indexOfFirstSpace == -1 ?
                    trimmedOrderByClause : trimmedOrderByClause.Remove(indexOfFirstSpace);
                if (string.IsNullOrEmpty(propertyName))
                {
                    continue;
                }
                if (!mappingDictionary.TryGetValue(propertyName, out List<MappedProperty> mappedProperties))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }
                if (mappedProperties == null)
                {
                    throw new ArgumentNullException(propertyName);
                }
                mappedProperties.Reverse();
                foreach (var destinationProperty in mappedProperties)
                {
                    if (destinationProperty.Revert)
                    {
                        orderDescending = !orderDescending;
                    }
                    source = source.OrderBy(destinationProperty.Name + (orderDescending ? " descending" : " ascending"));
                }
            }

            return source;
        }

        public static IQueryable<object> ToDynamicQueryable<TSource>
            (this IQueryable<TSource> source, string fields, Dictionary<string, List<MappedProperty>> mappingDictionary)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (mappingDictionary == null)
            {
                throw new ArgumentNullException(nameof(mappingDictionary));
            }

            if (string.IsNullOrWhiteSpace(fields))
            {
                return (IQueryable<object>)source;
            }

            fields = fields.ToLower();
            var fieldsAfterSplit = fields.Split(',').ToList();
            if (!fieldsAfterSplit.Contains("id", StringComparer.InvariantCultureIgnoreCase))
            {
                fieldsAfterSplit.Add("id");
            }
            var selectClause = "new (";

            foreach (var field in fieldsAfterSplit)
            {
                var propertyName = field.Trim();
                if (string.IsNullOrEmpty(propertyName))
                {
                    continue;
                }

                var key = mappingDictionary.Keys.SingleOrDefault(k => String.CompareOrdinal(k.ToLower(), propertyName.ToLower()) == 0);
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }
                var mappedProperties = mappingDictionary[key];
                if (mappedProperties == null)
                {
                    throw new ArgumentNullException(key);
                }
                foreach (var destinationProperty in mappedProperties)
                {
                    selectClause += $" {destinationProperty.Name},";
                }
            }

            selectClause = selectClause.Substring(0, selectClause.Length - 1) + ")";
            return (IQueryable<object>)source.Select(selectClause);
        }
    }
    
}
