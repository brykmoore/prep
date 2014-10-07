using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.sorting
{
  public class AscendingOrderComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
  {
    IComparer<ItemToCompare> original;
    PropertyType[] order;
    IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor; 
    public AscendingOrderComparer(PropertyType[] order, IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor)
    {
        this.order = order;
        this.accessor = accessor;
    }

    public int Compare(ItemToCompare x, ItemToCompare y)
    {
        var first_value = Array.IndexOf(order, accessor(x));
        var second_value = Array.IndexOf(order, accessor(y));

        return first_value.CompareTo(second_value);
    }
  }
}