using System;
using prep.utility;

namespace prep.collections
{
  public class Match<ItemToMatch>
  {
    public static MatchFactory<ItemToMatch, PropertyType> with<PropertyType>(
      IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor)
    {
      return new MatchFactory<ItemToMatch, PropertyType>(accessor);
    }

    public static ComparableMatchFactory<ItemToMatch, PropertyType> with_comparable_attribute<PropertyType>(
      IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor) where PropertyType : IComparable<PropertyType>

    {
      return new ComparableMatchFactory<ItemToMatch, PropertyType>(accessor, with(accessor));
    }
  }
}