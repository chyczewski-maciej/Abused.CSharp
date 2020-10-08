using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbusedCSharp.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValueOut> Map<TKey, TValueIn, TValueOut>(this Dictionary<TKey, TValueIn> dictionary, Func<TValueIn, TValueOut> map)
        {
            return dictionary.Map((_, value) => map(value));
        }

        public static Dictionary<TKey, TValueOut> Map<TKey, TValueIn, TValueOut>(this Dictionary<TKey, TValueIn> dictionary, Func<TKey, TValueIn, TValueOut> map)
        {
            return dictionary.AsEnumerable().Select(kvp => kvp.Map(map)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value, dictionary.Comparer);
        }

        public static Dictionary<TKey, TValue> Filter<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Func<TValue, Boolean> predicate)
        {
            return dictionary.Filter((_, value) => predicate(value));
        }

        public static Dictionary<TKey, TValue> Filter<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Func<TKey, TValue, Boolean> predicate)
        {
            return dictionary.Where(kvp => predicate(kvp.Key, kvp.Value)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value, dictionary.Comparer);
        }
    }
}
