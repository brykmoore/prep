using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.sorting
{
  public class AscendingAttributeComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare> where PropertyType
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
}