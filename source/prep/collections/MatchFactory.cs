using System.Collections.Generic;
using prep.matching;
using prep.utility;

namespace prep.collections
{
  public class MatchFactory<ItemToMatch, PropertyType>
  {
    IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor;

    public MatchFactory(IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> equal_to(params PropertyType[] values)
    {
      return new ConditionalMatch<ItemToMatch>(x =>
      {
        var items = new List<PropertyType>(values);

        var value_to_find = accessor(x);

        return items.Contains(value_to_find);
      });
    }

    public IMatchA<ItemToMatch> not_equal_to(PropertyType value)
    {
      throw new System.NotImplementedException();
    }
  }
}