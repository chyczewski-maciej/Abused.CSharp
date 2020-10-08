using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AbusedCSharp.Extensions
{
    public static class KeyVaulePairExtensions
    {
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
        {
            key = kvp.Key;
            value = kvp.Value;
        }

        public static KeyValuePair<TKey, TValueOut> Map<TKey, TValueIn, TValueOut>(this KeyValuePair<TKey, TValueIn> kvp, Func<TValueIn, TValueOut> map)
            => new KeyValuePair<TKey, TValueOut>(kvp.Key, map(kvp.Value));
        public static KeyValuePair<TKey, TValueOut> Map<TKey, TValueIn, TValueOut>(this KeyValuePair<TKey, TValueIn> kvp, Func<TKey, TValueIn, TValueOut> map)
            => new KeyValuePair<TKey, TValueOut>(kvp.Key, map(kvp.Key, kvp.Value));

        public static KeyValuePair<TKey, TValue> ToKeyValuePair<TKey, TValue>(this (TKey key, TValue value) tuple) => new KeyValuePair<TKey, TValue>(tuple.key, tuple.value);

    }
}
