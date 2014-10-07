using System;
using System.ComponentModel;
using prep.ranges;
using prep.utility;

namespace prep.matching
{
  public static class MatchResultExtensions
  {
    public static ReturnType equal_to<ItemToMatch, PropertyType, ReturnType>(this ICreateAMatchResult<ItemToMatch, PropertyType, ReturnType> extension_point, params PropertyType[] values)
    {
      return from_criteria(extension_point, new EqualToAny<PropertyType>(values));
    }

    public static ReturnType from_criteria<ItemToMatch, PropertyType, ReturnType>(this ICreateAMatchResult<ItemToMatch, PropertyType, ReturnType> extension_point, IMatchA<PropertyType> attribute_criteria)
    {
      return extension_point.create_match_result(attribute_criteria);
    }

    public static ReturnType from_condition<ItemToMatch, PropertyType, ReturnType>(this ICreateAMatchResult<ItemToMatch, PropertyType, ReturnType> extension_point, Condition<ItemToMatch> condition)
    {
      return extension_point.create_match_result(condition);
    }

    public static ReturnType greater_than<ItemToMatch, PropertyType, ReturnType>(this ICreateAMatchResult<ItemToMatch, PropertyType, ReturnType> extension_point, PropertyType value) where PropertyType : IComparable<PropertyType>
    {
      return from_criteria(extension_point, new GreaterThan<PropertyType>(value));
    }

    public static ReturnType between<ItemToMatch, PropertyType, ReturnType>(this ICreateAMatchResult<ItemToMatch, PropertyType, ReturnType> extension_point, PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
    {
      return from_criteria(extension_point, new Between<PropertyType>(start, end));
    }

    public static ReturnType falls_in<ItemToMatch, PropertyType, ReturnType>(this ICreateAMatchResult<ItemToMatch, PropertyType, ReturnType> extension_point, IContainValues<PropertyType> range) where PropertyType : IComparable<PropertyType>
    {
      return from_criteria(extension_point, new FallsInRange<PropertyType>(range));
    }

  }
}
