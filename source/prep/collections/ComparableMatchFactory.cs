using System;
using prep.matching;
using prep.utility;

namespace prep.collections
{
  public class ComparableMatchFactory<ItemToMatch, PropertyType> : ICreateMatchers<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor;
    ICreateMatchers<ItemToMatch, PropertyType> original_factory;

    public ComparableMatchFactory(IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor, ICreateMatchers<ItemToMatch, PropertyType> original_factory)
    {
      this.accessor = accessor;
      this.original_factory = original_factory;
    }

    public IMatchA<ItemToMatch> greater_than(PropertyType value)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchA<ItemToMatch> between(PropertyType start, PropertyType end)
    {
      return new ConditionalMatch<ItemToMatch>(x =>
      {
        var value = accessor(x);
        return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
      });
    }

    public IMatchA<ItemToMatch> equal_to(params PropertyType[] values)
    {
      return original_factory.equal_to(values);
    }

    public IMatchA<ItemToMatch> not_equal_to(PropertyType value)
    {
      return original_factory.not_equal_to(value);
    }
  }
}