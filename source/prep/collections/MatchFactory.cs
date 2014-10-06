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

    public IMatchA<ItemToMatch> equal_to(PropertyType value)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).Equals(value));
    }

    public IMatchA<ItemToMatch> equal_to_any(params PropertyType[] values)
    {
      throw new System.NotImplementedException();
    }
  }
}