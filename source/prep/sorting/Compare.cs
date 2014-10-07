using System;
using System.Collections.Generic;
using prep.collections;
using prep.utility;

namespace prep.sorting
{
  public class Compare<ItemToCompare>
  {
    public static IComparer<ItemToCompare> by_descending<PropertyType>(
      IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return by(accessor).reverse();
    }

    public static IComparer<ItemToCompare> by<PropertyType>(
      IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new AscendingAttributeComparer<ItemToCompare, PropertyType>(accessor);
    }

    public static IComparer<ItemToCompare> by<PropertyType>(IGetTheValueOfAProperty<ItemToCompare, PropertyType> accessor,
      params PropertyType[] order)
    {
      throw new NotImplementedException();
    }
  }
}