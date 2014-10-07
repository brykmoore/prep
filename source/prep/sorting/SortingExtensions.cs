using System.Collections.Generic;

namespace prep.sorting
{
  public static class SortingExtensions
  {
    public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items, IComparer<T> comparer)
    {
      var sorted = new List<T>(items);
      sorted.Sort(comparer);
      return sorted;
    }
  }
}