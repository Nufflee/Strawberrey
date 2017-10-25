using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Strawberrey.CLI
{
  public static class DictionaryExtension
  {
    public static void AddAll<TKey, TValue, T>(this IDictionary<TKey, TValue> dictionary, ICollection<TKey> keys, ICollection<TValue> values)
    {
      Debug.Assert(keys.Count == values.Count);

      for (int i = 0; i < keys.Count; i++)
      {
        dictionary.Add(keys.ElementAt(i), values.ElementAt(i));
      }
    }
  }
}