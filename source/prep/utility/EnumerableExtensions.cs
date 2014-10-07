using System;
using System.Collections.Generic;
using prep.matching;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (var item in items)
        yield return item;
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Condition<T> criteria)
    {
      foreach (var item in items)
        if (criteria(item)) yield return item;
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, IMatchA<T> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }

    public static FilteringExtensionPoint<ItemToFilter, PropertyType> where<ItemToFilter, PropertyType>(this IEnumerable<ItemToFilter> items,
      IGetTheValueOfAProperty<ItemToFilter, PropertyType> accessor)
    {
      throw new NotImplementedException(); 
    }
  }
}