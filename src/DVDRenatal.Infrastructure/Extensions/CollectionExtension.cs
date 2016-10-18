using System;
using System.Collections.Generic;
using System.Linq;

namespace DVDRenatal.Infrastructure.Extensions
{
    public static class CollectionExtension {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source) {
            return source ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (T element in source.OrEmptyIfNull()) {
                action(element);
            }

            return source;
        }

        /// <summary>
        /// the method will return true only when the collection is null or 0 count
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable) {
            enumerable = enumerable.OrEmptyIfNull();
            return !enumerable.Any();
        }

        /// <summary>
        /// the method will return true only when the collection is more than 0
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable) {
            enumerable = enumerable.OrEmptyIfNull();
            return enumerable.Any();
        }
    }
}