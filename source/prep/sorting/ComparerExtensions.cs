using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.sorting
{
  public static class ComparerExtensions
  {
    public static IComparer<T> reverse<T>(this IComparer<T> to_reverse)
    {
      return new ReverseComparer<T>(to_reverse);
    }

    public static IComparer<T> then_by<T>(this IComparer<T> first, IComparer<T> second)
    {
      return new CombinedComparer<T>(first, second);
    }

    public static IComparer<T> then_by<T, PropertyType>(this IComparer<T> first, IGetTheValueOfAProperty<T,PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return first.then_by(Compare<T>.by(accessor));
    }

    public static IComparer<T> then_by_descending<T, PropertyType>(this IComparer<T> first, IGetTheValueOfAProperty<T,PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return first.then_by(Compare<T>.by_descending(accessor));
    }
  }
}