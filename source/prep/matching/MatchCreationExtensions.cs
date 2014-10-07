using System;
using prep.utility;

namespace prep.matching
{
  public static class MatchCreationExtensions
  {
    public static IMatchA<ItemToMatch> equal_to<ItemToMatch, PropertyType>(this IProvideAccessToCreateMatchers<ItemToMatch, PropertyType> extension_point, params PropertyType[] values)
    {
      return from_criteria(extension_point, new EqualToAny<PropertyType>(values));
    }

    public static IMatchA<ItemToMatch> from_criteria<ItemToMatch, PropertyType>(this IProvideAccessToCreateMatchers<ItemToMatch, PropertyType> extension_point, IMatchA<PropertyType> attribute_criteria)
    {
      return extension_point.create_match_from(attribute_criteria);
    }

    public static IMatchA<ItemToMatch> from_condition<ItemToMatch, PropertyType>(this IProvideAccessToCreateMatchers<ItemToMatch, PropertyType> extension_point, Condition<ItemToMatch> condition)
    {
      return new ConditionalMatch<ItemToMatch>(condition);
    }

    public static IMatchA<ItemToMatch> greater_than<ItemToMatch, PropertyType>(this IProvideAccessToCreateMatchers<ItemToMatch, PropertyType> extension_point, PropertyType value) where PropertyType : IComparable<PropertyType>
    {
      return from_criteria(extension_point, new GreaterThan<PropertyType>(value));
    }

    public static IMatchA<ItemToMatch> between<ItemToMatch, PropertyType>(this IProvideAccessToCreateMatchers<ItemToMatch, PropertyType> extension_point, PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
    {
      return from_criteria(extension_point, new Between<PropertyType>(start, end));
    }
  }
}
