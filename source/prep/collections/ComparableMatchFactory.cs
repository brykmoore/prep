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
    }

    public IMatchA<ItemToMatch> greater_than(PropertyType value)
    {
        return return_conditional_match(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchA<ItemToMatch> between(PropertyType start, PropertyType end)
    {
        return return_conditional_match(x =>
        {
            var value = accessor(x);
            return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
        });
    }

    public ConditionalMatch<ItemToMatch> return_conditional_match(Condition<ItemToMatch> condition)
    {
        return new ConditionalMatch<ItemToMatch>(condition);
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