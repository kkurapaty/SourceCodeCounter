using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SourceCodeCounter.Common
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Usage: bool descending = (sortDirection = SortDirection.Descending);
        /// PersonGridView.DataSource = persons.OrderBy(descending, p => p.Age, p => p.Name, p => p.Gender).ToList();
        /// </summary>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> keySelector, bool descending)
        {
            if (enumerable == null)
            {
                return null;
            }

            if (descending)
            {
                return enumerable.OrderByDescending(keySelector);
            }

            return enumerable.OrderBy(keySelector);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, IComparable> keySelector1, Func<TSource, IComparable> keySelector2, params Func<TSource, IComparable>[] keySelectors)
        {
            if (enumerable == null)
            {
                return null;
            }

            IEnumerable<TSource> current = enumerable;

            if (keySelectors != null)
            {
                for (int i = keySelectors.Length - 1; i >= 0; i--)
                {
                    current = current.OrderBy(keySelectors[i]);
                }
            }

            current = current.OrderBy(keySelector2);

            return current.OrderBy(keySelector1);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable, bool descending, Func<TSource, IComparable> keySelector, params Func<TSource, IComparable>[] keySelectors)
        {
            if (enumerable == null)
            {
                return null;
            }

            IEnumerable<TSource> current = enumerable;

            if (keySelectors != null)
            {
                for (int i = keySelectors.Length - 1; i >= 0; i--)
                {
                    current = current.OrderBy(keySelectors[i], descending);
                }
            }

            return current.OrderBy(keySelector, descending);
        }
    }


}