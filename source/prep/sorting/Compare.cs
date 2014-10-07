using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.sorting
{
  public class Compare<ItemToCompare>
  {
    public static IComparer<ItemToCompare> by_descending<PropertyType>(
      IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new DescendingAttributeComparer<PropertyType>(accessor);
    }

    class DescendingAttributeComparer<PropertyType> : IComparer<ItemToCompare> where PropertyType
      : IComparable<PropertyType>
    {
      IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor;

      public DescendingAttributeComparer(IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor)
      {
        this.accessor = accessor;
      }

      public int Compare(ItemToCompare x, ItemToCompare y)
      {
        var first_value = accessor(x);
        var second_value = accessor(y);

        return -first_value.CompareTo(second_value);
      }
    }

    class AscendingAttributeComparer<PropertyType> : IComparer<ItemToCompare> where PropertyType
      : IComparable<PropertyType>
    {
      IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor;

      public AscendingAttributeComparer(IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor)
      {
        this.accessor = accessor;
      }

      public int Compare(ItemToCompare x, ItemToCompare y)
      {
        var first_value = accessor(x);
        var second_value = accessor(y);

        return first_value.CompareTo(second_value);
      }
    }

    public static IComparer<ItemToCompare> by<PropertyType>(
      IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new AscendingAttributeComparer<PropertyType>(accessor);
    }
  }
}